import React, { useState } from 'react';
import { motion } from 'framer-motion';
import './LoginPortal.css';

const LoginPortal = ({ onLoginSuccess }) => {
  const [name, setName] = useState('');
  const [age, setAge] = useState('');
  const [email, setEmail] = useState('');
  const [dob, setDob] = useState('');
  const [status, setStatus] = useState('');

  const handleSignIn = () => {
    if (!name) {
      setStatus('ERROR: Name is required');
      return;
    }
    
    setStatus('ACCESS GRANTED ✔ Welcome Racer');
    // Call the parent application callback after a short delay
    setTimeout(() => {
      onLoginSuccess(name);
    }, 1000);
  };

  const handleSignOut = () => {
    setName('');
    setAge('');
    setEmail('');
    setDob('');
    setStatus('SESSION TERMINATED ❌ Signed Out');
  };

  return (
    <motion.div 
      className="login-portal-overlay"
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      exit={{ opacity: 0, scale: 0.95 }}
      transition={{ duration: 0.4 }}
    >
      <div className="login-cyber-background"></div>
      <div className="login-orb login-orb--blue"></div>
      <div className="login-orb login-orb--purple"></div>
      <div className="login-orb login-orb--cyan"></div>

      <div className="login-wrapper">
        <motion.div 
          className="login-card"
          initial={{ y: 50, opacity: 0 }}
          animate={{ y: 0, opacity: 1 }}
          transition={{ delay: 0.2 }}
        >
          <div className="login-card-header">
            <div className="login-title-group">
              <div className="login-game-title">Cyber Trap</div>
              <div className="login-subtitle">Neon Racer Access Node</div>
            </div>
          </div>

          <form className="login-form" onSubmit={(e) => { e.preventDefault(); handleSignIn(); }}>
            <div className="login-field">
              <label>Name</label>
              <input 
                type="text" 
                placeholder="Enter your racer tag" 
                value={name}
                onChange={e => setName(e.target.value)}
              />
            </div>

            <div className="login-field">
              <label>Age</label>
              <input 
                type="number" 
                placeholder="Age" 
                value={age}
                onChange={e => setAge(e.target.value)}
              />
            </div>

            <div className="login-field">
              <label>Email</label>
              <input 
                type="email" 
                placeholder="Enter email" 
                value={email}
                onChange={e => setEmail(e.target.value)}
              />
            </div>

            <div className="login-field">
              <label>Date of Birth</label>
              <input 
                type="date" 
                value={dob}
                onChange={e => setDob(e.target.value)}
              />
            </div>

            <div className="login-button-row">
              <button type="button" className="login-button" onClick={handleSignIn}>
                Sign In
              </button>
              <button type="button" className="login-button login-btn-signout" onClick={handleSignOut}>
                Sign Out
              </button>
            </div>

            {status && (
              <div className="login-status-message" style={{ color: status.includes('GRANTED') ? '#3dff8b' : '#ff3366' }}>
                {status}
              </div>
            )}
          </form>
        </motion.div>
      </div>
    </motion.div>
  );
};

export default LoginPortal;
