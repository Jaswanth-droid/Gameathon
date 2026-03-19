import React from 'react';
import './kinetic.css';

const PhonePopup = ({ onAction }) => {
  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/70 backdrop-blur-sm animate-in fade-in duration-300">
      <div className="w-[340px] h-[580px] bg-[#111] rounded-[40px] border-8 border-[#222] shadow-2xl overflow-hidden flex flex-col font-sans">
        {/* Status Bar */}
        <div className="h-7 bg-[#1a1a1a] flex justify-between items-center px-6 text-[12px] text-white">
          <span>9:41</span>
          <div className="flex gap-1">
            <span>📶</span>
            <span>🔋</span>
          </div>
        </div>

        {/* Notch */}
        <div className="absolute top-0 left-1/2 -translate-x-1/2 w-32 h-6 bg-black rounded-b-2xl z-10"></div>

        <div className="flex-1 flex flex-col pt-12 items-center">
          {/* Avatar */}
          <div className="w-24 h-24 bg-[#333] rounded-full flex items-center justify-center text-4xl mb-6 shadow-xl border border-white/5">
            🏦
          </div>

          <h2 className="text-white text-2xl font-semibold mb-1">National Secure Bank</h2>
          <p className="text-[#8e8e93] text-sm mb-4">+91 98XX-XXXX42</p>
          <p className="text-[#8e8e93] text-xs animate-pulse">incoming call...</p>

          <div className="mt-12 w-full px-8 flex justify-between">
            <div className="flex flex-col items-center gap-1.5 opacity-60">
              <div className="w-11 h-11 bg-[#333] rounded-full flex items-center justify-center text-lg">🔇</div>
              <span className="text-[10px] text-[#8e8e93]">Mute</span>
            </div>
            <div className="flex flex-col items-center gap-1.5 opacity-60">
              <div className="w-11 h-11 bg-[#333] rounded-full flex items-center justify-center text-lg">💬</div>
              <span className="text-[10px] text-[#8e8e93]">Message</span>
            </div>
            <div className="flex flex-col items-center gap-1.5 opacity-60">
              <div className="w-11 h-11 bg-[#333] rounded-full flex items-center justify-center text-lg">⏰</div>
              <span className="text-[10px] text-[#8e8e93]">Remind</span>
            </div>
          </div>

          <div className="mt-20 w-full px-12 flex justify-between items-end">
            <button 
              onClick={() => onAction('decline')}
              className="flex flex-col items-center gap-2 group"
            >
              <div className="w-16 h-16 bg-[#ff3b30] hover:bg-[#ff453a] rounded-full flex items-center justify-center text-3xl text-white transition-all transform group-hover:scale-110 shadow-lg">
                ✕
              </div>
              <span className="text-xs text-[#ff3b30] font-medium">Decline</span>
            </button>

            <button 
              onClick={() => onAction('accept')}
              className="flex flex-col items-center gap-2 group"
            >
              <div className="w-16 h-16 bg-[#34c759] hover:bg-[#30d158] rounded-full flex items-center justify-center text-3xl text-white transition-all transform group-hover:scale-110 shadow-lg">
                ✓
              </div>
              <span className="text-xs text-[#34c759] font-medium">Accept</span>
            </button>
          </div>
        </div>

        {/* Home Indicator */}
        <div className="h-1.5 w-32 bg-[#444] rounded-full mx-auto mb-2 mt-auto"></div>
      </div>
    </div>
  );
};

export default PhonePopup;
