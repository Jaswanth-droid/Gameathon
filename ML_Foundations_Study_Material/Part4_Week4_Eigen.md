# 📘 Machine Learning Foundations — Study Material
# PART 4: WEEK 4 — EIGENVALUES & DIAGONALIZATION (Videos 18–21)

---

## VIDEO 18: W4_L2 — Eigenvalues & Eigenvectors

### 📌 Key Concepts

**Definition:** For a square matrix A, if Av = λv for some non-zero vector v, then:
- λ = **eigenvalue**
- v = **eigenvector** corresponding to λ

**Intuition:** An eigenvector is a special direction that only gets **scaled** (not rotated) by the matrix transformation. The eigenvalue tells you the scaling factor.

**How to Find Eigenvalues:**
1. Solve: det(A − λI) = 0 → the **characteristic equation**
2. This gives a polynomial in λ of degree n (for n×n matrix)
3. Roots = eigenvalues

**How to Find Eigenvectors:**
For each eigenvalue λᵢ, solve: (A − λᵢI)v = 0

**Worked Example:**
```
A = [[4, 1],
     [2, 3]]

det(A − λI) = det([[4−λ, 1],[2, 3−λ]]) = (4−λ)(3−λ) − 2 = λ² − 7λ + 10

λ² − 7λ + 10 = 0 → (λ−5)(λ−2) = 0 → λ₁ = 5, λ₂ = 2
```

For λ₁ = 5: (A−5I)v = 0 → [[−1,1],[2,−2]]v = 0 → v₁ = (1,1)
For λ₂ = 2: (A−2I)v = 0 → [[2,1],[2,1]]v = 0 → v₂ = (1,−2)

**Properties:**
- Sum of eigenvalues = trace(A) = sum of diagonal elements
- Product of eigenvalues = det(A)
- Symmetric matrices (A = Aᵀ) always have real eigenvalues

**Why This Matters for ML:**
- **PCA:** Eigenvectors of covariance matrix = principal components
- **Spectral clustering:** Uses eigenvalues of graph Laplacian
- **Stability analysis:** System is stable if all |λᵢ| < 1

### 🧮 Practice Problems

**P1:** Find eigenvalues of A = [[2, 1],[1, 2]].
**Answer:** det(A−λI) = (2−λ)²−1 = λ²−4λ+3 = (λ−3)(λ−1) = 0. Eigenvalues: λ = 3, 1.

**P2:** Find eigenvectors for the matrix in P1.
**Answer:** λ=3: (A−3I)v=0 → [[−1,1],[1,−1]]v=0 → v=(1,1). λ=1: (A−I)v=0 → [[1,1],[1,1]]v=0 → v=(1,−1).

**P3:** Verify: trace(A) = sum of eigenvalues and det(A) = product of eigenvalues for P1.
**Answer:** trace = 2+2 = 4 = 3+1 ✓. det = 4−1 = 3 = 3×1 ✓.

**P4:** A 3×3 matrix has eigenvalues 2, −1, 3. What is det(A)? What is trace(A)?
**Answer:** det(A) = 2×(−1)×3 = −6. trace(A) = 2+(−1)+3 = 4.

---

## VIDEO 19: W4_L3 — Diagonalization of a Matrix

### 📌 Key Concepts

**Diagonalization:** A matrix A is diagonalizable if:
```
A = SΛS⁻¹
```
Where:
- S = matrix whose columns are eigenvectors of A
- Λ = diagonal matrix of eigenvalues
- S⁻¹ = inverse of S

**When is A Diagonalizable?**
A (n×n matrix) is diagonalizable if and only if it has n linearly independent eigenvectors.

**Why Diagonalize?**
1. **Matrix Powers:** Aᵏ = SΛᵏS⁻¹ (just raise diagonal entries to power k!)
2. **Understanding transformations:** Diagonalization decomposeds a complex transformation into simple scalings along eigenvector directions
3. **Solving systems of ODEs:** x'(t) = Ax becomes decoupled

**Computing Aᵏ efficiently:**
```
Aᵏ = S [[λ₁ᵏ, 0], [0, λ₂ᵏ]] S⁻¹
```
Instead of multiplying A k times (O(kn³)), we just compute eigenvalue powers!

**Example:**
```
A = [[2, 1],[0, 3]]

Eigenvalues: λ₁ = 2, λ₂ = 3
Eigenvectors: v₁ = (1,0), v₂ = (1,1)
S = [[1,1],[0,1]], Λ = [[2,0],[0,3]]

A¹⁰ = S [[2¹⁰, 0],[0, 3¹⁰]] S⁻¹ = S [[1024, 0],[0, 59049]] S⁻¹
```

### 🧮 Practice Problems

**P1:** Diagonalize A = [[5, 4],[1, 2]].
**Answer:** Eigenvalues: (5−λ)(2−λ)−4 = λ²−7λ+6 = (λ−6)(λ−1)=0. λ=6,1. For λ=6: v=(4,1). For λ=1: v=(−1,1). S=[[4,−1],[1,1]], Λ=[[6,0],[0,1]].

**P2:** Using diagonalization, compute A³ for A = [[1,1],[0,2]].
**Answer:** Eigenvalues: 1, 2. v₁=(1,0), v₂=(1,1). S=[[1,1],[0,1]], S⁻¹=[[1,−1],[0,1]]. A³ = S·diag(1,8)·S⁻¹ = [[1,1],[0,1]]·[[1,0],[0,8]]·[[1,−1],[0,1]] = [[1,7],[0,8]].

**P3:** Is A = [[0,1],[0,0]] diagonalizable? Why or why not?
**Answer:** Eigenvalues: both 0. Eigenvectors: only span{(1,0)} — only 1 independent eigenvector for a 2×2 matrix. NOT diagonalizable.

---

## VIDEO 20: W4_L4 — Solving Fibonacci Sequence Using Diagonalization

### 📌 Key Concepts

**Fibonacci:** F₀=0, F₁=1, Fₙ = Fₙ₋₁ + Fₙ₋₂

**Matrix Formulation:**
```
[Fₙ₊₁]   [1 1]   [Fₙ  ]
[Fₙ  ] = [1 0] × [Fₙ₋₁]
```

Let u₀ = [F₁, F₀]ᵀ = [1, 0]ᵀ and A = [[1,1],[1,0]].
Then uₙ = Aⁿ u₀.

**Using Diagonalization:**
```
A = [[1,1],[1,0]]
Eigenvalues: λ₁ = (1+√5)/2 ≈ 1.618 (golden ratio φ)
             λ₂ = (1−√5)/2 ≈ −0.618

Fₙ = (φⁿ − ψⁿ)/√5     where ψ = (1−√5)/2
```

This is **Binet's formula** — gives Fₙ directly without recursion!

**Key Insight:** This shows how diagonalization converts a recursive problem into a closed-form solution. The dominant eigenvalue φ determines the growth rate of Fibonacci numbers.

### 🧮 Practice Problems

**P1:** Use Binet's formula to compute F₆.
**Answer:** F₆ = (φ⁶ − ψ⁶)/√5 = (17.944 − 0.0557)/2.236 ≈ 8. (Actual F₆ = 8 ✓)

**P2:** Set up the matrix formulation for the recurrence aₙ = 3aₙ₋₁ − 2aₙ₋₂.
**Answer:** A = [[3, −2],[1, 0]]. State: [aₙ, aₙ₋₁]ᵀ = A·[aₙ₋₁, aₙ₋₂]ᵀ.

**P3:** The dominant eigenvalue of the Fibonacci matrix is φ ≈ 1.618. What does this tell us about the growth of Fibonacci numbers?
**Answer:** Fₙ ≈ φⁿ/√5 for large n. Each Fibonacci number is approximately φ ≈ 1.618 times the previous one. Growth is exponential with base φ.

---

## VIDEO 21: W4_L5 — Orthogonally Diagonalizable Matrices

### 📌 Key Concepts

**Spectral Theorem:** A real matrix A is orthogonally diagonalizable (A = QΛQᵀ with Q orthogonal) if and only if A is **symmetric** (A = Aᵀ).

**Properties of Symmetric Matrices:**
1. All eigenvalues are real (not complex)
2. Eigenvectors for distinct eigenvalues are automatically orthogonal
3. A = QΛQᵀ where Q is an orthogonal matrix (Qᵀ = Q⁻¹)

**Positive Definite Matrices:**
A symmetric matrix A is positive definite if all eigenvalues > 0.
- Equivalent: xᵀAx > 0 for all non-zero x
- Positive definite → matrix is invertible
- The Hessian being positive definite ↔ local minimum

**Positive Semi-Definite:** All eigenvalues ≥ 0 (allows zero eigenvalues).

**Spectral Decomposition:**
```
A = λ₁q₁q₁ᵀ + λ₂q₂q₂ᵀ + ... + λₙqₙqₙᵀ
```
Each term is a rank-1 matrix scaled by an eigenvalue. This is the foundation of PCA!

**Connection to PCA:**
- Covariance matrix Σ is symmetric & positive semi-definite
- Spectral decomposition of Σ gives principal components
- Keep the terms with largest λᵢ = most important directions

### 🧮 Practice Problems

**P1:** Is A = [[2,1],[1,2]] positive definite?
**Answer:** Eigenvalues: 3 and 1 (from Video 18 P1). Both > 0 → **Yes, positive definite.**

**P2:** Orthogonally diagonalize A = [[3,1],[1,3]].
**Answer:** Eigenvalues: 4, 2. v₁=(1,1)/√2, v₂=(1,−1)/√2. Q = [[1/√2,1/√2],[1/√2,−1/√2]], Λ = [[4,0],[0,2]]. A = QΛQᵀ.

**P3:** Can a non-symmetric matrix be orthogonally diagonalizable?
**Answer:** No. The Spectral Theorem guarantees this is ONLY possible for symmetric matrices.

**P4:** If eigenvalues of a symmetric matrix are 5, 0, −2, is it positive definite? Positive semi-definite?
**Answer:** Not positive definite (has negative eigenvalue −2). Not positive semi-definite (negative eigenvalue). It is **indefinite**.
