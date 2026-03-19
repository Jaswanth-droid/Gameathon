import React from 'react';
import './kinetic.css';

const EmailPhone = ({ onChoice }) => {
  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/60 backdrop-blur-sm animate-in fade-in duration-300">
      <div className="relative w-[340px] h-[640px] bg-[#111] rounded-[40px] border-8 border-[#333] shadow-2xl overflow-hidden flex flex-col font-sans">
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

        <div className="flex-1 flex flex-col pt-4">
          {/* App Header */}
          <div className="h-10 bg-[#1c1c1e] flex justify-between items-center px-4">
            <span className="text-white text-lg flex items-center gap-2">✉️ Inbox</span>
            <span className="text-[#ff3b30] text-sm">1 new</span>
          </div>

          <div className="bg-[#222] px-3 py-1.5 flex items-center gap-2">
            <span className="text-[#007aff] text-[10px]">●</span>
            <span className="text-[#8e8e93] text-[12px]">Unread (1)</span>
          </div>

          <div className="p-3 flex-1 overflow-y-auto">
            {/* Email Card */}
            <div className="bg-[#1c1c1e] rounded-xl p-4 shadow-lg border border-[#333]">
              <div className="flex justify-between items-start mb-1">
                <span className="text-white font-bold text-sm">IT_SECURITY</span>
                <span className="text-[#8e8e93] text-[11px]">9:32 AM</span>
              </div>
              <div className="text-[#ff9500] text-[10px] mb-2">@cybersafe-helpdesk.net</div>
              
              <div className="text-white font-bold text-sm leading-tight mb-2">
                URGENT — Verify Your Account or Face Suspension
              </div>
              
              <div className="text-[#8e8e93] text-xs leading-relaxed mb-3">
                Dear Employee, your account will be locked in 24 hours unless you verify...
              </div>

              <div className="bg-[#2c2c2e] rounded-lg p-3 flex items-center gap-2 border border-[#444]">
                <span className="text-sm">🔗</span>
                <span className="text-[#007aff] text-[11px] truncate">cybersafe-helpdesk.net/verify</span>
              </div>
            </div>
          </div>

          {/* Action Buttons */}
          <div className="p-4 space-y-3 mb-2">
            <button 
              onClick={() => onChoice('inspect')}
              className="w-full bg-[#007aff] hover:bg-[#0a84ff] text-white py-3 rounded-xl text-sm font-medium transition-colors flex items-center justify-center gap-2 shadow-lg"
            >
              <span>🔍</span> Open & Inspect Carefully
            </button>
            <button 
              onClick={() => onChoice('delete')}
              className="w-full bg-[#333] hover:bg-[#444] text-white py-3 rounded-xl text-sm font-medium transition-colors flex items-center justify-center gap-2 shadow-lg"
            >
              <span>🗑️</span> Delete Without Opening
            </button>
            <button 
              onClick={() => onChoice('click')}
              className="w-full bg-[#ff3b30] hover:bg-[#ff453a] text-white py-3 rounded-xl text-sm font-medium transition-colors flex items-center justify-center gap-2 shadow-lg"
            >
              <span>⚡</span> Tap Link Now — It's Urgent!
            </button>
          </div>

          {/* Home Indicator */}
          <div className="h-1.5 w-32 bg-[#444] rounded-full mx-auto mb-2"></div>
        </div>
      </div>
    </div>
  );
};

export default EmailPhone;
