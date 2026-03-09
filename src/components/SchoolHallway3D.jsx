import React, { useRef, useState } from 'react'
import { Canvas, useFrame } from '@react-three/fiber'
import { OrbitControls, PerspectiveCamera, Text, Float, MeshDistortMaterial } from '@react-three/drei'
import * as THREE from 'three'

const Leo3D = ({ isSpeaking }) => {
    const group = useRef()

    // Animation loop for Leo
    useFrame((state) => {
        const t = state.clock.getElapsedTime()
        if (group.current) {
            // Gentle idle bobbing
            group.current.position.y = Math.sin(t * 2) * 0.1

            if (isSpeaking) {
                // More active movement when speaking
                group.current.rotation.y = Math.sin(t * 10) * 0.1
                group.current.scale.setScalar(1 + Math.sin(t * 20) * 0.02)
            }
        }
    })

    return (
        <group ref={group} position={[2, -1, 0]} scale={[1.2, 1.2, 1.2]}>
            {/* Head */}
            <mesh position={[0, 1.5, 0]}>
                <sphereGeometry args={[0.4, 32, 32]} />
                <meshStandardMaterial color="#ffdbac" />
            </mesh>

            {/* Hair - Leo's signature style */}
            <mesh position={[0, 1.7, 0.1]}>
                <boxGeometry args={[0.5, 0.4, 0.5]} />
                <meshStandardMaterial color="#4b3621" />
            </mesh>

            {/* Body / Hoodie */}
            <mesh position={[0, 0.6, 0]}>
                <capsuleGeometry args={[0.4, 1, 4, 16]} />
                <meshStandardMaterial color="#39ff14" /> {/* Neon Green Hoodie */}
            </mesh>

            {/* Legs */}
            <mesh position={[-0.2, -0.4, 0]}>
                <cylinderGeometry args={[0.15, 0.12, 0.8]} />
                <meshStandardMaterial color="#222" />
            </mesh>
            <mesh position={[0.2, -0.4, 0]}>
                <cylinderGeometry args={[0.15, 0.12, 0.8]} />
                <meshStandardMaterial color="#222" />
            </mesh>

            {/* The "Hyped Game" handheld */}
            <mesh position={[-0.5, 0.8, 0.4]} rotation={[0, 0.5, 0]}>
                <boxGeometry args={[0.6, 0.3, 0.1]} />
                <meshStandardMaterial color="#00f3ff" emissive="#00f3ff" emissiveIntensity={0.5} />
            </mesh>
        </group>
    )
}

const Environment = () => {
    return (
        <group>
            {/* Floor */}
            <mesh rotation={[-Math.PI / 2, 0, 0]} position={[0, -2, 0]}>
                <planeGeometry args={[50, 50]} />
                <meshStandardMaterial color="#111" />
            </mesh>

            {/* Walls */}
            <mesh position={[0, 2, -10]}>
                <planeGeometry args={[50, 10]} />
                <meshStandardMaterial color="#1a1a1a" />
            </mesh>

            {/* School Lockers (Abstract) */}
            {[...Array(10)].map((_, i) => (
                <mesh key={i} position={[-8 + i * 2, 0, -9.8]}>
                    <boxGeometry args={[1.5, 4, 0.2]} />
                    <meshStandardMaterial color="#333" />
                </mesh>
            ))}

            {/* Lighting */}
            <ambientLight intensity={0.5} />
            <pointLight position={[10, 10, 10]} intensity={1} color="#00f3ff" />
            <spotLight position={[-10, 10, 10]} angle={0.15} penumbra={1} intensity={1} color="#39ff14" />
        </group>
    )
}

export default function SchoolHallway3D({ isSpeaking }) {
    return (
        <div style={{ width: '100%', height: '400px', background: '#000', borderRadius: '8px', overflow: 'hidden' }}>
            <Canvas shadows>
                <PerspectiveCamera makeDefault position={[0, 0, 8]} fov={50} />
                <Environment />
                <Leo3D isSpeaking={isSpeaking} />
                <OrbitControls enableZoom={false} enablePan={false} minPolarAngle={Math.PI / 2.5} maxPolarAngle={Math.PI / 1.8} />
            </Canvas>
        </div>
    )
}
