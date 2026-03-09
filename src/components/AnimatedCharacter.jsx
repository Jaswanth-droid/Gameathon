import { motion, AnimatePresence } from 'framer-motion'

const AnimatedCharacter = ({ type, isSpeaking }) => {
    const getCharacterStyle = () => {
        switch (type) {
            case 'Leo':
                return {
                    primaryColor: 'var(--neon-blue)',
                    secondaryColor: 'var(--warning)',
                    label: 'LEO'
                }
            case 'Hacker':
                return {
                    primaryColor: 'var(--danger)',
                    secondaryColor: '#000',
                    label: 'THE SHADOW'
                }
            case 'Sarah':
                return {
                    primaryColor: 'var(--neon-green)',
                    secondaryColor: 'white',
                    label: 'SARAH'
                }
            default:
                return null
        }
    }

    const style = getCharacterStyle()
    if (!style) return null

    return (
        <motion.div
            className={`character-sprite ${type.toLowerCase()}`}
            initial={{ x: -100, opacity: 0 }}
            animate={{ x: 0, opacity: 1 }}
            exit={{ x: 100, opacity: 0 }}
            transition={{ type: 'spring', stiffness: 100 }}
        >
            <div className="avatar-container">
                {/* Placeholder Avatar with Motion */}
                <motion.div
                    className="avatar-base"
                    animate={isSpeaking ? {
                        scale: [1, 1.05, 1],
                        rotate: [0, 2, -2, 0]
                    } : {}}
                    transition={{ repeat: Infinity, duration: 2 }}
                    style={{ borderColor: style.primaryColor }}
                >
                    {type === 'Hacker' ? (
                        <div className="hacker-avatar">
                            <div className="glitch-eye left"></div>
                            <div className="glitch-eye right"></div>
                        </div>
                    ) : (
                        <div className="default-avatar" style={{ backgroundColor: style.primaryColor + '33' }}>
                            <div className="avatar-eye left"></div>
                            <div className="avatar-eye right"></div>
                            <div className={`avatar-mouth ${isSpeaking ? 'talking' : ''}`}></div>
                        </div>
                    )}
                </motion.div>

                <motion.div
                    className="character-label"
                    animate={{ opacity: [0.5, 1, 0.5] }}
                    transition={{ repeat: Infinity, duration: 1.5 }}
                    style={{ backgroundColor: style.primaryColor }}
                >
                    {style.label}
                </motion.div>
            </div>
        </motion.div>
    )
}

export default AnimatedCharacter
