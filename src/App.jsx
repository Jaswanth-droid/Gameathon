import { useState, useEffect } from 'react'
import { motion, AnimatePresence } from 'framer-motion'
import LevelMap from './components/LevelMap'
import LoginPortal from './components/LoginPortal'
import GameEngineContainer from './components/GameEngineContainer'
import MissionPlayer from './components/MissionPlayer'
import './App.css'

function App() {
  const [userName, setUserName] = useState('Player')
  const [isGameStarted, setIsGameStarted] = useState(false)
  const [showLevelMap, setShowLevelMap] = useState(false)
  const [currentProgress, setCurrentProgress] = useState(1)
  const [activeGameLevel, setActiveGameLevel] = useState(null)
  const [gameMode, setGameMode] = useState('authentic') // 'authentic' or 'native'

  const handleLevelSelect = (level) => {
    if (level.id > currentProgress) return;
    setActiveGameLevel(level.id);
  }

  const handleLevelComplete = (levelId) => {
    if (levelId === currentProgress) {
      setCurrentProgress(prev => Math.min(prev + 1, 10));
    }
    setActiveGameLevel(null);
    setShowLevelMap(true);
  }

  // Effect to listen for mode switches from the bridge iframe
  useEffect(() => {
    const handleBridgeMessage = (event) => {
      if (event.data && event.data.type === 'SWITCH_TO_NATIVE') {
        setGameMode('native');
      }
    };
    window.addEventListener('message', handleBridgeMessage);
    return () => window.removeEventListener('message', handleBridgeMessage);
  }, []);

  // Handle Login
  if (!isGameStarted) {
    return (
      <AnimatePresence>
        <LoginPortal 
          onLoginSuccess={(name) => {
            setUserName(name);
            setIsGameStarted(true);
            setShowLevelMap(true);
          }}
        />
      </AnimatePresence>
    );
  }

  // Handle Mission Player (Native React Mode)
  if (activeGameLevel && gameMode === 'native') {
    return (
      <MissionPlayer 
        startNodeId={`level${activeGameLevel}_start`}
        onComplete={() => handleLevelComplete(activeGameLevel)}
        onBack={() => setActiveGameLevel(null)}
      />
    );
  }

  // Handle Game Engine View (Authentic Ren'Py Mode)
  if (activeGameLevel && gameMode === 'authentic') {
    return (
      <GameEngineContainer 
        levelId={activeGameLevel}
        onComplete={handleLevelComplete}
        onBack={() => setActiveGameLevel(null)}
      />
    );
  }

  // Handle Level Map View (Candy Crush Style)
  return (
    <div className="game-container">
      <div className="cinematic-bars top"></div>
      
      <header className="game-header">
        <div className="user-id">AGENT: {userName.toUpperCase()}</div>
        <div className="stats">
          <div className="stat-item">
            <span>UNLOCKED: </span>
            <span className="stat-value">{currentProgress}/10</span>
          </div>
        </div>
      </header>

      <main className="map-view-area">
        <LevelMap 
          currentProgress={currentProgress} 
          onSelectLevel={handleLevelSelect} 
        />
      </main>

      <div className="cinematic-bars bottom"></div>

      <footer className="terminal-footer">
        <div className="terminal-text">
          {`>>`} CONNECTION_STABLE // READY_TO_DEPLOY
        </div>
      </footer>
    </div>
  );
}

export default App;
