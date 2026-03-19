import React from 'react';
import './kinetic.css';

const WifiSelection = ({ onAction }) => {
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

        <div className="flex-1 flex flex-col pt-4">
          {/* Settings Header */}
          <div className="h-11 bg-[#1c1c1e] flex items-center px-4 border-b border-[#333]">
            <span className="text-[#007aff] text-sm">‹ Settings</span>
            <span className="flex-1 text-center text-white font-semibold text-lg">Wi-Fi</span>
          </div>

          <div className="mt-4 px-4 py-3 bg-[#1c1c1e] flex justify-between items-center border-y border-[#333]">
            <span className="text-white">Wi-Fi</span>
            <div className="w-11 h-6 bg-[#34c759] rounded-full relative">
              <div className="absolute right-0.5 top-0.5 w-5 h-5 bg-white rounded-full shadow-md"></div>
            </div>
          </div>

          <div className="mt-8 px-4 pb-1">
            <span className="text-[#8e8e93] text-[11px] font-medium tracking-wider uppercase">Available Networks</span>
          </div>

          <div className="bg-[#1c1c1e] border-y border-[#333]">
            {/* Evil Twin */}
            <button 
              onClick={() => onAction('evil_twin')}
              className="w-full px-4 py-3 flex justify-between items-center hover:bg-[#2c2c2e] transition-colors border-b border-[#333]"
            >
              <div className="flex items-center gap-3">
                <span className="text-xl">📶</span>
                <div className="flex flex-col items-start">
                  <span className="text-white text-sm">BeanAndBrew_FreeWiFi</span>
                  <span className="text-[#ff9500] text-[10px]">Open Network</span>
                </div>
              </div>
              <span className="text-[#ff9500] text-xl">🔓</span>
            </button>

            {/* Legit */}
            <button 
              onClick={() => onAction('legit')}
              className="w-full px-4 py-3 flex justify-between items-center hover:bg-[#2c2c2e] transition-colors border-b border-[#333]"
            >
              <div className="flex items-center gap-3">
                <span className="text-xl">📶</span>
                <div className="flex flex-col items-start">
                  <span className="text-white text-sm">BeanAndBrew_Guest</span>
                  <span className="text-[#34c759] text-[10px]">WPA2 Secured</span>
                </div>
              </div>
              <span className="text-[#34c759] text-xl">🔒</span>
            </button>

            {/* Other */}
            <button 
              onClick={() => onAction('other')}
              className="w-full px-4 py-3 flex justify-between items-center hover:bg-[#2c2c2e] transition-colors opacity-50"
            >
              <div className="flex items-center gap-3">
                <span className="text-xl text-gray-500">📶</span>
                <div className="flex flex-col items-start">
                  <span className="text-gray-400 text-sm">HomeNetwork_5G</span>
                  <span className="text-[#34c759] text-[10px]">WPA3 Secured</span>
                </div>
              </div>
              <span className="text-[#34c759] text-xl">🔒</span>
            </button>
          </div>

          <div className="p-6">
            <div className="bg-[#222]/50 p-3 rounded-lg border border-[#ff9500]/20 flex gap-2 items-center">
              <span className="text-[#ff9500]">⚠️</span>
              <span className="text-[#ff9500] text-[10px] italic">Open networks don't encrypt your data</span>
            </div>
          </div>
        </div>

        {/* Home Indicator */}
        <div className="h-1.5 w-32 bg-[#444] rounded-full mx-auto mb-2"></div>
      </div>
    </div>
  );
};

export default WifiSelection;
