import React, { useEffect, useState } from 'react';
import './GameEngineContainer.css';

/**
 * GameEngineContainer
 * This component hosts the original game engines (Ren'Py / Unity) via an iframe.
 */
const GameEngineContainer = ({ levelId, onComplete, onBack }) => {
  const [isLoading, setIsLoading] = useState(true);

  // Map level IDs to their respective build paths
  const getGameUrl = (id) => {
    return `/games/renpy/index.html?level=${id}`;
  };

  useEffect(() => {
    const handleMessage = (event) => {
      if (event.data && event.data.type === 'LEVEL_DONE') {
        onComplete(event.data.level);
      }
    };

    window.addEventListener('message', handleMessage);
    return () => window.removeEventListener('message', handleMessage);
  }, [onComplete]);

  return (
    <div className="engine-container">
      {/* Control Header */}
      <header className="engine-header">
        <div className="engine-header-left">
          <button onClick={onBack} className="exit-button">
            <span>«</span> EXIT TO MAP
          </button>
          <div className="header-divider"></div>
          <span className="engine-meta">
            NEURAL_LINK // SECTOR_{levelId} // AUTH_ACTIVE
          </span>
        </div>
        
        <div className="engine-header-right">
          <div className={`status-dot ${isLoading ? 'loading' : 'active'}`}></div>
          <span className="status-text">
            {isLoading ? 'SYNCING_NEURAL_STREAM...' : 'LINK_ESTABLISHED'}
          </span>
        </div>
      </header>

      {/* Engine Viewport */}
      <main className="engine-viewport">
        {isLoading && (
          <div className="loading-overlay">
            <div className="loader-scan"></div>
            <span className="loading-text">INITIALIZING NEURAL LINK...</span>
          </div>
        )}
        
        <iframe
          src={getGameUrl(levelId)}
          title={`Game Level ${levelId}`}
          className="engine-iframe"
          onLoad={() => setIsLoading(false)}
          allow="autoplay; fullscreen; keyboard"
        />
      </main>

      {/* Subtle Footer Overlay */}
      <footer className="engine-footer">
        <div className="footer-text">
          AUTHENTIC_ENGINE_WRAPPER // v2.0.4 // ENCRYPTED_STREAM
        </div>
      </footer>
    </div>
  );
};

export default GameEngineContainer;
