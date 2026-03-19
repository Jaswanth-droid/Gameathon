import React, { useState, useEffect } from 'react';
import { motion, AnimatePresence } from 'framer-motion';
import { storyData } from '../data/storyData';
import AnimatedCharacter from './AnimatedCharacter';
import EmailPhone from './EmailPhone';
import BruteForceDemo from './BruteForceDemo';
import PhonePopup from './PhonePopup';
import InstallerUI from './InstallerUI';
import WifiSelection from './WifiSelection';
import './MissionPlayer.css';

const MissionPlayer = ({ startNodeId, onComplete, onBack }) => {
  const [currentNodeId, setCurrentNodeId] = useState(startNodeId);
  const [currentScore, setCurrentScore] = useState(0);

  const currentNode = storyData[currentNodeId];

  // Auto-finish if we hit map or something missing
  useEffect(() => {
    if (!currentNode || currentNodeId === 'level_map') {
      onComplete(currentScore);
    }
  }, [currentNodeId]);

  if (!currentNode || currentNodeId === 'level_map') return null;

  const handleChoice = (choice) => {
    if (choice.scoreChange) setCurrentScore(prev => prev + choice.scoreChange);
    setCurrentNodeId(choice.nextId);
  };

  const handleModuleComplete = (result) => {
    const nextId = currentNode.moduleResults?.[result] || currentNode.nextId;
    setCurrentNodeId(nextId);
  };

  // Render content based on node type
  const renderNodeContent = () => {
    if (currentNode.type === 'module_email') {
      return (
        <div className="minigame-wrapper">
          <EmailPhone onFinished={handleModuleComplete} />
        </div>
      );
    }
    if (currentNode.type === 'module_bruteforce') {
      return (
        <div className="minigame-wrapper">
          <BruteForceDemo onFinished={() => handleModuleComplete()} />
        </div>
      );
    }
    if (currentNode.type === 'module_phone') {
      return (
        <div className="minigame-wrapper">
          <PhonePopup onFinished={handleModuleComplete} />
        </div>
      );
    }
    if (currentNode.type === 'module_installer') {
      return (
        <div className="minigame-wrapper">
          <InstallerUI onFinished={handleModuleComplete} />
        </div>
      );
    }
    if (currentNode.type === 'module_wifi') {
      return (
        <div className="minigame-wrapper">
          <WifiSelection onFinished={handleModuleComplete} />
        </div>
      );
    }

    return (
      <div className="mission-content">
        <header className="mission-header">
          <div className="mission-title">NEURAL_STREAM // {currentNodeId.toUpperCase()}</div>
          <button onClick={onBack} className="exit-button">EXIT_STREAM</button>
        </header>

        <div className="character-display-area">
          <AnimatePresence mode="wait">
            {currentNode.speaker && currentNode.speaker !== 'System' && (
              <AnimatedCharacter 
                key={currentNode.speaker}
                type={currentNode.speaker}
                isSpeaking={true}
                characterImage={currentNode.characterImage}
              />
            )}
          </AnimatePresence>
        </div>

        <motion.div 
          className="dialogue-container"
          initial={{ y: 50, opacity: 0 }}
          animate={{ y: 0, opacity: 1 }}
          key={currentNodeId}
        >
          {currentNode.speakerName && (
            <div className="speaker-tag">{currentNode.speakerName}</div>
          )}
          
          <div className="dialogue-text">
            {currentNode.text}
          </div>

          <div className="choice-list">
            {currentNode.choices?.map((choice, index) => (
              <motion.button
                key={index}
                className="choice-button"
                whileHover={{ scale: 1.02 }}
                whileTap={{ scale: 0.98 }}
                onClick={() => handleChoice(choice)}
              >
                <span>{choice.text}</span>
                <span className="choice-arrow">→</span>
              </motion.button>
            ))}
          </div>
        </motion.div>

        <footer className="mission-footer">
          SC_CORE_v4 // SCORE: {currentScore} // SESSION_ACTIVE
        </footer>
      </div>
    );
  };

  return (
    <div className="mission-player-overlay">
      <div 
        className="mission-background" 
        style={{ backgroundImage: `url('/assets/login_bg.png')` }} 
      />
      {renderNodeContent()}
    </div>
  );
};

export default MissionPlayer;
