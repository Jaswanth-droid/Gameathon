import React, { useState } from 'react';
import './kinetic.css';

const InstallerUI = ({ onAction }) => {
  const [toolbarChecked, setToolbarChecked] = useState(true);

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/60 backdrop-blur-sm animate-in fade-in duration-300">
      <div className="w-[600px] bg-[#f0f0f0] rounded-xl shadow-2xl overflow-hidden border border-gray-400 flex flex-col font-sans">
        {/* Header/Title Bar */}
        <div className="bg-gradient-to-r from-blue-700 to-blue-500 px-4 py-2 flex justify-between items-center">
          <span className="text-white text-sm font-semibold">SuperCodeEditor v3.1 — Setup Wizard</span>
          <div className="flex gap-2">
            <span className="text-white opacity-50 text-xl cursor-default hover:opacity-100 italic font-bold">_</span>
            <span className="text-white opacity-50 text-xl cursor-default hover:opacity-100">×</span>
          </div>
        </div>

        <div className="p-10 flex-1">
          <h2 className="text-[#333] text-xl font-bold mb-6">Installation Options</h2>
          
          <div className="space-y-5">
            <div className="flex items-start gap-4">
              <input type="checkbox" checked readOnly className="mt-1.5 w-4 h-4 rounded border-gray-300 cursor-not-allowed" />
              <div>
                <div className="text-[#333] font-medium">Install SuperCodeEditor (required)</div>
                <div className="text-[#999] text-xs">Standard program files and libraries.</div>
              </div>
            </div>

            <div className="flex items-start gap-4">
              <input type="checkbox" checked readOnly className="mt-1.5 w-4 h-4 rounded border-gray-300 cursor-not-allowed" />
              <div>
                <div className="text-[#333] font-medium">Create Desktop Shortcut</div>
                <div className="text-[#999] text-xs">Access the program easily from your home screen.</div>
              </div>
            </div>

            <div className="flex items-start gap-4 p-4 bg-yellow-50 border border-yellow-200 rounded-lg">
              <input 
                type="checkbox" 
                checked={toolbarChecked} 
                onChange={() => setToolbarChecked(!toolbarChecked)}
                className="mt-1.5 w-5 h-5 rounded border-gray-400 accent-blue-600 cursor-pointer"
              />
              <div>
                <div className="text-blue-800 font-bold text-sm">Install BonusSearchToolbar™ (Recommended)</div>
                <div className="text-gray-500 text-[11px] leading-tight mt-1">
                  BonusSearchToolbar™ may modify browser settings, set default search engine, and collect usage data.
                  Optimized for speed and productivity.
                </div>
              </div>
            </div>
          </div>
        </div>

        {/* Footer Buttons */}
        <div className="bg-gray-200 px-8 py-5 flex justify-end gap-4 border-t border-gray-300">
          <button 
            onClick={() => onAction('cancel')}
            className="px-8 py-2 bg-[#ddd] hover:bg-[#ccc] text-gray-700 font-semibold rounded border border-gray-400 transition-colors"
          >
            CANCEL
          </button>
          <button 
            onClick={() => onAction(toolbarChecked)}
            className="px-10 py-2 bg-[#26c] hover:bg-[#37d] text-white font-bold rounded shadow-md transition-colors"
          >
            INSTALL
          </button>
        </div>
      </div>
    </div>
  );
};

export default InstallerUI;
