import { motion, AnimatePresence } from 'framer-motion'

const AnimatedCharacter = ({ type, isSpeaking, characterImage }) => {
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
            case 'Arjun':
                return {
                    primaryColor: 'var(--neon-blue)',
                    secondaryColor: 'white',
                    label: 'ARJUN'
                }
            case 'Prof. Meera':
                return {
                    primaryColor: 'var(--neon-purple)',
                    secondaryColor: 'white',
                    label: 'PROF. MEERA'
                }
            case 'Rahul':
                return {
                    primaryColor: 'var(--neon-blue)',
                    secondaryColor: 'white',
                    label: 'RAHUL'
                }
            case 'Ananya':
                return {
                    primaryColor: 'var(--neon-green)',
                    secondaryColor: 'white',
                    label: 'ANANYA'
                }
            case 'Riya':
                return {
                    primaryColor: 'var(--neon-purple)',
                    secondaryColor: 'white',
                    label: 'RIYA'
                }
            case 'Rajesh':
                return {
                    primaryColor: 'var(--danger)',
                    secondaryColor: 'white',
                    label: 'RAJESH (BANK)'
                }
            case 'Vikram':
                return {
                    primaryColor: 'var(--neon-blue)',
                    secondaryColor: 'white',
                    label: 'VIKRAM'
                }
            case 'Naveen':
                return {
                    primaryColor: 'var(--neon-green)',
                    secondaryColor: 'white',
                    label: 'NAVEEN'
                }
            case 'Sanjay':
                return {
                    primaryColor: 'var(--neon-blue)',
                    secondaryColor: 'white',
                    label: 'SANJAY (IT)'
                }
            case 'Kavita':
                return {
                    primaryColor: 'var(--neon-purple)',
                    secondaryColor: 'white',
                    label: 'KAVITA (ARCHITECT)'
                }
            case 'Zoe':
                return {
                    primaryColor: 'var(--neon-blue)',
                    secondaryColor: 'white',
                    label: 'ZOE (ADVOCATE)'
                }
            case 'Amit':
                return {
                    primaryColor: 'var(--neon-purple)',
                    secondaryColor: 'white',
                    label: 'DR. AMIT'
                }
            case 'Maya':
                return {
                    primaryColor: 'var(--neon-green)',
                    secondaryColor: 'white',
                    label: 'MAYA (LEAD)'
                }
            default:
                return {
                    primaryColor: 'var(--neon-blue)',
                    secondaryColor: 'white',
                    label: type ? type.toUpperCase() : 'SYSTEM'
                }
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
                <motion.div
                    className="avatar-base image-version"
                    animate={isSpeaking ? {
                        scale: [1, 1.02, 1],
                        y: [0, -5, 0]
                    } : {}}
                    transition={{ repeat: Infinity, duration: 2 }}
                    style={{ borderColor: style.primaryColor }}
                >
                    {characterImage ? (
                        <div className="sprite-image-wrapper">
                            <img src={characterImage} alt={type} className="character-img" />
                        </div>
                    ) : (
                        type === 'Hacker' ? (
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
                        )
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
