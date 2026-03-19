import { motion } from 'framer-motion';
import LevelNode from './LevelNode';
import './LevelMap.css';
import './kinetic.css';

const levels = [
  { id: 1, title: 'Phishing Alert', y: 1700 },
  { id: 2, title: 'Password Fortress', y: 1540 },
  { id: 3, title: 'Social Shield', y: 1380 },
  { id: 4, title: 'Malware Purge', y: 1220 },
  { id: 5, title: 'WiFi Guardian', y: 1060 },
  { id: 6, title: 'Ransomware Raid', y: 900 },
  { id: 7, title: '2FA Master', y: 740 },
  { id: 8, title: 'Safe Web', y: 580 },
  { id: 9, title: 'Data Vault', y: 420 },
  { id: 10, title: 'The Final Breach', y: 260 },
];

const LevelMap = ({ currentProgress, onSelectLevel }) => {
  const codeSnippets = ["SECRET_KEY", "ENCRYPT_AES", "HASH_SHA256", "AUTH_TOKEN", "ACCESS_GRANTED"];

  // Sine wave parameters
  const mapHeight = 1800;
  const mapWidth = 500; 
  const centerX = 250;
  const amplitude = 160; 
  const frequency = 0.004; 

  const getX = (y) => centerX + Math.sin(y * frequency) * amplitude;

  const pathD = () => {
    let d = `M ${getX(mapHeight - 50)} ${mapHeight - 50}`;
    for (let y = mapHeight - 60; y >= 50; y -= 5) {
      d += ` L ${getX(y)} ${y}`;
    }
    return d;
  };

  return (
    <div className="level-map-container">
      <div className="map-particles" style={{ position: 'fixed', inset: 0, pointerEvents: 'none' }}>
        {[...Array(15)].map((_, i) => (
          <motion.div
            key={i}
            initial={{ y: "110%", x: `${Math.random() * 100}%`, opacity: 0 }}
            animate={{ 
              y: "-10%", 
              opacity: [0, 0.5, 0],
            }}
            transition={{ duration: 15 + Math.random() * 10, repeat: Infinity, ease: "linear", delay: Math.random() * 10 }}
            style={{ position: 'absolute', color: '#00f3ff', fontSize: '10px', fontFamily: 'monospace' }}
          >
            {codeSnippets[Math.floor(Math.random() * codeSnippets.length)]}
          </motion.div>
        ))}
      </div>
      <div className="map-scroll-area">
        <svg className="map-path-svg" viewBox={`0 0 ${mapWidth} ${mapHeight}`}>
          <defs>
            <linearGradient id="pathGradient" x1="0%" y1="0%" x2="0%" y2="100%">
              <stop offset="0%" stopColor="#00f3ff" stopOpacity="0.8" />
              <stop offset="50%" stopColor="#9d00ff" stopOpacity="0.8" />
              <stop offset="100%" stopColor="#00f3ff" stopOpacity="0.8" />
            </linearGradient>
            <filter id="glow">
              <feGaussianBlur stdDeviation="6" result="coloredBlur"/>
              <feMerge>
                <feMergeNode in="coloredBlur"/>
                <feMergeNode in="SourceGraphic"/>
              </feMerge>
            </filter>
          </defs>
          <motion.path
            d={pathD()}
            fill="none"
            stroke="url(#pathGradient)"
            strokeWidth="10"
            strokeDasharray="20 15"
            filter="url(#glow)"
            initial={{ pathLength: 0, opacity: 0 }}
            animate={{ pathLength: 1, opacity: 0.8 }}
            transition={{ duration: 3, ease: "easeInOut" }}
          />
        </svg>

        <div className="nodes-container">
          {levels.map((level, index) => {
            const isLocked = level.id > currentProgress;
            const isCurrent = level.id === currentProgress;
            
            // Calculate Y position from bottom up
            const yPos = level.y;
            const xOffset = getX(yPos);
            
            return (
              <div 
                key={level.id} 
                className="node-wrapper"
                style={{ 
                  left: `${xOffset}px`,
                  top: `${yPos}px`
                }}
              >
                <LevelNode 
                  level={level}
                  isLocked={isLocked}
                  isCurrent={isCurrent}
                  onClick={onSelectLevel}
                />
              </div>
            );
          })}
        </div>
      </div>
    </div>
  );
};

export default LevelMap;
