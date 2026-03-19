import { motion } from 'framer-motion';
import './LevelMap.css';

const LevelNode = ({ level, isLocked, isCurrent, onClick }) => {
  return (
    <motion.div
      className={`level-node ${isLocked ? 'locked' : ''} ${isCurrent ? 'current' : ''}`}
      whileHover={!isLocked ? { scale: 1.15, filter: "brightness(1.2)" } : {}}
      whileTap={!isLocked ? { scale: 0.95 } : {}}
      onClick={() => !isLocked && onClick(level)}
    >
      <div className="node-content">
        {isLocked ? (
          <span className="lock-icon">🔒</span>
        ) : (
          <span className="level-number">{level.id}</span>
        )}
      </div>
      <div className="node-label">{level.title}</div>
      
      {isCurrent && (
        <motion.div 
          className="current-indicator"
          animate={{ scale: [1, 1.2, 1], opacity: [0.5, 1, 0.5] }}
          transition={{ repeat: Infinity, duration: 2 }}
        />
      )}
    </motion.div>
  );
};

export default LevelNode;
