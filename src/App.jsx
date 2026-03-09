import { useState, useEffect } from 'react'
import { motion, AnimatePresence } from 'framer-motion'
import { storyData } from './data/storyData'
import AnimatedCharacter from './components/AnimatedCharacter'
import SchoolHallway3D from './components/SchoolHallway3D'
import './App.css'

function App() {
  const [currentSceneId, setCurrentSceneId] = useState('start')
  const [userName, setUserName] = useState('Player')
  const [isGameStarted, setIsGameStarted] = useState(false)
  const [score, setScore] = useState(100)
  const [lastFeedback, setLastFeedback] = useState('')
  const [showFeedback, setShowFeedback] = useState(false)
  const [isGlitching, setIsGlitching] = useState(false)

  const currentScene = storyData[currentSceneId]

  useEffect(() => {
    if (currentScene.type === 'breach') {
      setIsGlitching(true)
    } else {
      setIsGlitching(false)
    }
  }, [currentSceneId])

  const handleChoice = (choice) => {
    if (choice.feedback) {
      setLastFeedback(choice.feedback)
      setShowFeedback(true)
    } else {
      setShowFeedback(false)
    }

    if (choice.scoreChange) {
      setScore(prev => Math.max(0, prev + choice.scoreChange))
    }

    setCurrentSceneId(choice.nextId)
  }

  if (!isGameStarted) {
    return (
      <motion.div
        className="start-screen"
        initial={{ opacity: 0 }}
        animate={{ opacity: 1 }}
      >
        <motion.h1
          className="glitch-text"
          animate={{ scale: [1, 1.05, 1] }}
          transition={{ repeat: Infinity, duration: 4 }}
        >
          CYBERGUARD: CHRONICLES
        </motion.h1>
        <div className="name-input-container">
          <p>IDENTIFY YOURSELF, USER:</p>
          <input
            type="text"
            placeholder="Enter Name..."
            value={userName}
            onChange={(e) => setUserName(e.target.value)}
          />
          <motion.button
            className="start-btn"
            onClick={() => setIsGameStarted(true)}
            whileHover={{ scale: 1.1 }}
            whileTap={{ scale: 0.9 }}
          >
            INITIALIZE SIMULATION
          </motion.button>
        </div>
      </motion.div>
    )
  }

  const renderVisualArea = () => {
    if (currentScene.speakerName === 'School Hallway') {
      return (
        <div className="three-d-render-area">
          <SchoolHallway3D isSpeaking={currentScene.speaker === 'Leo'} />
        </div>
      )
    }

    return (
      <div className="character-stage">
        <AnimatedCharacter
          type={currentScene.speaker}
          isSpeaking={currentScene.speaker !== 'Scene' && currentScene.speaker !== 'System'}
        />
      </div>
    )
  }

  return (
    <div className={`game-container ${isGlitching ? 'glitch-state' : ''}`}>
      <div className="cinematic-bars top"></div>

      <header className="game-header">
        <div className="user-id">ID: {userName.toUpperCase()}</div>
        <div className="stats">
          <div className="stat-item">
            <span>SEC_LEVEL: </span>
            <span className="stat-value" style={{ color: score > 70 ? 'var(--neon-green)' : 'var(--danger)' }}>
              {score}%
            </span>
          </div>
        </div>
      </header>

      <main className="cinematic-viewport">
        <AnimatePresence mode="wait">
          <motion.div
            key={currentSceneId}
            className="scene-display"
            initial={{ opacity: 0, scale: 0.95 }}
            animate={{ opacity: 1, scale: 1 }}
            exit={{ opacity: 0, x: 20 }}
            transition={{ duration: 0.5 }}
          >
            <div className="scene-header">
              <span className="location-tag">{currentScene.speakerName}</span>
            </div>

            <div className="scene-content">
              <div className="visual-container">
                {renderVisualArea()}
              </div>

              <div className="dialogue-box">
                {currentScene.speaker !== 'Scene' && currentScene.speaker !== 'System' && (
                  <div className="character-name">{currentScene.speaker}</div>
                )}
                <p className="dialogue-text">{currentScene.text}</p>
              </div>
            </div>

            <div className="interaction-area">
              <div className="choice-list">
                {currentScene.choices.map((choice, index) => (
                  <motion.button
                    key={index}
                    className={`choice-btn ${choice.isCritical ? 'critical' : ''}`}
                    onClick={() => handleChoice(choice)}
                    whileHover={{ x: 5, backgroundColor: 'rgba(255,255,255,0.1)' }}
                  >
                    {choice.text}
                  </motion.button>
                ))}
              </div>
            </div>
          </motion.div>
        </AnimatePresence>

        <AnimatePresence>
          {showFeedback && (
            <motion.div
              className="system-log-overlay"
              onClick={() => setShowFeedback(false)}
              initial={{ opacity: 0 }}
              animate={{ opacity: 1 }}
              exit={{ opacity: 0 }}
            >
              <motion.div
                className="log-panel"
                initial={{ y: 50, scale: 0.9 }}
                animate={{ y: 0, scale: 1 }}
                exit={{ y: 50, opacity: 0 }}
              >
                <div className="log-header">(!) SYSTEM ALERT - SECURITY BREACH</div>
                <div className="log-body">
                  <p>{lastFeedback}</p>
                </div>
                <div className="log-footer">CLICK TO ACKNOWLEDGE</div>
              </motion.div>
            </motion.div>
          )}
        </AnimatePresence>
      </main>

      <div className="cinematic-bars bottom"></div>

      <footer className="terminal-footer">
        <div className="terminal-text">{'>>'} SYSTEM_RUNNING // THREAT_LEVEL: {isGlitching ? 'CRITICAL' : 'STABLE'}</div>
      </footer>
    </div>
  )
}

export default App
