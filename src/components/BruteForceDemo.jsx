import React, { useState, useEffect } from 'react';
import './kinetic.css';

const BruteForceDemo = ({ onClose }) => {
  const [attempts, setAttempts] = useState([]);
  const [cracked, setCracked] = useState(false);
  const commonPasswords = ["aaa123", "admin1", "pass123", "qwerty", "123456", "password"];

  useEffect(() => {
    let currentIdx = 0;
    const interval = setInterval(() => {
      if (currentIdx < commonPasswords.length) {
        setAttempts(prev => [...prev, commonPasswords[currentIdx]]);
        if (commonPasswords[currentIdx] === "password") {
          setCracked(true);
          clearInterval(interval);
        }
        currentIdx++;
      }
    }, 500);

    return () => clearInterval(interval);
  }, []);

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/80 backdrop-blur-md animate-in fade-in duration-300">
      <div className="w-[700px] bg-[#0a0a0a] border-2 border-[#ff3333]/30 rounded-2xl p-10 font-mono shadow-[0_0_50px_rgba(255,51,51,0.2)]">
        <h2 className="text-[#ff3333] text-3xl font-bold text-center mb-2 tracking-widest animate-pulse">
          ⚡ BRUTE FORCE ATTACK SIMULATION ⚡
        </h2>
        <div className="w-full h-0.5 bg-[#333] mb-8"></div>

        <div className="space-y-3 min-h-[300px]">
          {attempts.map((pwd, idx) => (
            <div key={idx} className={`text-xl ${pwd === 'password' ? 'text-[#ff3333] font-bold' : 'text-[#00ff99]/70'}`}>
              <span className="text-gray-500 mr-4">[{idx.toString().padStart(2, '0')}]</span>
              Attempting password: <span className="underline decoration-dotted">{pwd}</span>
            </div>
          ))}
          
          {cracked && (
            <div className="mt-8 p-6 bg-[#ff3333]/10 border border-[#ff3333]/30 rounded-xl animate-in zoom-in duration-500">
              <div className="text-[#ff3333] text-2xl font-bold text-center mb-2">
                ✓ PASSWORD CRACKED in 0.3 seconds!
              </div>
              <div className="text-[#ffaa00] text-center italic">
                "password" was found in the top 10 most common passwords.
              </div>
            </div>
          )}
        </div>

        {cracked && (
          <div className="mt-8 flex justify-center">
            <button 
              onClick={onClose}
              className="px-10 py-3 border-2 border-[#00ff99] text-[#00ff99] hover:bg-[#00ff99] hover:text-black font-bold rounded-lg transition-all duration-300 text-xl"
            >
              [[ CLOSE SIMULATION ]]
            </button>
          </div>
        )}
      </div>
    </div>
  );
};

export default BruteForceDemo;
