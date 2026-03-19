# 📘 Machine Learning Foundations — Study Material
# PART 3: WEEK 3 — LINEAR ALGEBRA (Videos 13–17)

---

## VIDEO 13: W3_L1 — Four Fundamental Subspaces

### 📌 Key Concepts

**Matrix A ∈ ℝᵐˣⁿ** has four fundamental subspaces:

| Subspace | Definition | Lives in | Dimension |
|----------|-----------|----------|-----------|
| Column Space C(A) | All linear combinations of columns of A | ℝᵐ | rank(A) = r |
| Row Space C(Aᵀ) | All linear combinations of rows of A | ℝⁿ | r |
| Null Space N(A) | All x such that Ax = 0 | ℝⁿ | n − r |
| Left Null Space N(Aᵀ) | All y such that Aᵀy = 0 | ℝᵐ | m − r |

**Rank-Nullity Theorem:** rank(A) + nullity(A) = n (number of columns)

**Orthogonality Relationships:**
- Column space ⊥ Left null space (both in ℝᵐ)
- Row space ⊥ Null space (both in ℝⁿ)

**How to Find Them:**
1. Row reduce A to echelon form
2. Pivot columns → basis for column space (use original columns!)
3. Non-zero rows of echelon form → basis for row space
4. Free variables → solve for null space basis
5. Row reduce Aᵀ for left null space

**Why This Matters for ML:**
- Column space = the set of all possible outputs Ax (predictions your model can make)
- If b is NOT in C(A), the system Ax = b has no exact solution → use least squares!

### 🧮 Practice Problems

**P1:** Find the rank, null space, and column space of A = [[1,2],[2,4]].
**Answer:** Row reduce: [[1,2],[0,0]]. Rank = 1. Column space = span{(1,2)}. Null space: x₁ + 2x₂ = 0 → x = t(−2, 1). Null space = span{(−2,1)}.

**P2:** A is 5×3 with rank 2. What are the dimensions of all four subspaces?
**Answer:** C(A): dim=2 in ℝ⁵. C(Aᵀ): dim=2 in ℝ³. N(A): dim=3−2=1 in ℝ³. N(Aᵀ): dim=5−2=3 in ℝ⁵.

**P3:** Can Ax = b have a solution if b is not in the column space of A?
**Answer:** No. Ax = b has a solution if and only if b ∈ C(A). If b ∉ C(A), we find the closest solution (least squares).

**P4:** Verify: For A = [[1,0],[0,1],[1,1]], show that null space and row space are orthogonal.
**Answer:** Row reduce: [[1,0],[0,1],[0,0]]. Rank=2, so null space has dim 2−2=0 (only {0}). The zero vector is orthogonal to everything. ✓

---

## VIDEO 14: W3_L2 — Orthogonal Vectors & Subspaces

### 📌 Key Concepts

**Orthogonal Vectors:** u and v are orthogonal if u · v = uᵀv = 0.

**Orthonormal Vectors:** Orthogonal AND unit length (‖u‖ = 1).

**Orthogonal Matrix Q:** A square matrix where QᵀQ = I (columns are orthonormal).
- Key property: Q⁻¹ = Qᵀ (inverse is just transpose!)
- Orthogonal matrices preserve lengths and angles

**Gram-Schmidt Process** (making any basis orthonormal):
Given vectors a₁, a₂, a₃:
```
u₁ = a₁
e₁ = u₁ / ‖u₁‖

u₂ = a₂ − (a₂·e₁)e₁
e₂ = u₂ / ‖u₂‖

u₃ = a₃ − (a₃·e₁)e₁ − (a₃·e₂)e₂
e₃ = u₃ / ‖u₃‖
```

**QR Decomposition:** Any matrix A = QR where Q is orthogonal, R is upper triangular.
- Computed via Gram-Schmidt on columns of A.

### 🧮 Practice Problems

**P1:** Apply Gram-Schmidt to a₁ = (1,1,0), a₂ = (1,0,1).
**Answer:** e₁ = (1,1,0)/√2. u₂ = (1,0,1) − [(1,0,1)·(1,1,0)/√2](1,1,0)/√2 = (1,0,1) − (1/2)(1,1,0) = (1/2, −1/2, 1). e₂ = (1/2,−1/2,1)/‖(1/2,−1/2,1)‖ = (1,−1,2)/√6.

**P2:** Verify that Q = [[1/√2, 1/√2],[−1/√2, 1/√2]] is orthogonal.
**Answer:** QᵀQ = [[1/√2,−1/√2],[1/√2,1/√2]] · [[1/√2,1/√2],[−1/√2,1/√2]] = [[1,0],[0,1]] = I ✓

**P3:** Why is the orthogonal matrix property Q⁻¹ = Qᵀ computationally valuable?
**Answer:** Computing a matrix inverse is O(n³) and numerically unstable. Transpose is O(n²) and exact. So Q⁻¹ = Qᵀ saves huge computation.

---

## VIDEO 15: W3_L3 — Projections

### 📌 Key Concepts

**Projection of vector b onto vector a:**
```
proj_a(b) = (aᵀb / aᵀa) · a
```

**Why Project?** When Ax = b has no solution, we find the closest point in C(A) to b.

**Projection Matrix (onto a line through a):**
```
P = (aaᵀ) / (aᵀa)
```
Properties: P² = P (applying twice = same), Pᵀ = P (symmetric)

**Error Vector:** e = b − Pb is perpendicular to a. This is the part of b NOT in the subspace.

**Key Geometric Insight:**
Any vector b = (projection onto subspace) + (error perpendicular to subspace)
```
b = Pb + (I − P)b
```

### 🧮 Practice Problems

**P1:** Project b = (1, 2, 3) onto a = (1, 1, 1).
**Answer:** proj = (aᵀb/aᵀa)·a = (6/3)(1,1,1) = (2,2,2). Error = (1,2,3)−(2,2,2) = (−1,0,1). Check: error·a = −1+0+1 = 0 ✓

**P2:** Find the projection matrix P for projecting onto a = (1, 2).
**Answer:** P = aaᵀ/(aᵀa) = [[1,2],[2,4]] / 5 = [[1/5, 2/5],[2/5, 4/5]]. Verify P² = P ✓

**P3:** Why is e = b − Pb perpendicular to a?
**Answer:** aᵀe = aᵀ(b − Pb) = aᵀb − aᵀ(aaᵀb)/(aᵀa) = aᵀb − aᵀb = 0. ✓

---

## VIDEO 16: W3_L4 — Least Squares & Projections onto a Subspace

### 📌 Key Concepts

**The Problem:** Ax = b has no exact solution when b ∉ C(A). Find x̂ that minimizes ‖Ax − b‖².

**The Normal Equation:**
```
AᵀA x̂ = Aᵀb
```
**Solution:** x̂ = (AᵀA)⁻¹Aᵀb (when AᵀA is invertible)

**Projection Matrix onto C(A):**
```
P = A(AᵀA)⁻¹Aᵀ
```

**Derivation (Geometric):**
- The error e = b − Ax̂ must be perpendicular to C(A)
- Perpendicular to C(A) means Aᵀe = 0
- Aᵀ(b − Ax̂) = 0 → AᵀAx̂ = Aᵀb ✓

**Connection to Linear Regression:**
- A = design matrix (features), b = target values
- x̂ = optimal weights = (AᵀA)⁻¹Aᵀb
- This IS the closed-form solution for linear regression!

### 🧮 Practice Problems

**P1:** Find the least squares solution: x₁ + x₂ = 1, x₁ + x₂ = 3, x₁ + x₂ = 2.
**Answer:** A = [[1,1],[1,1],[1,1]], b = (1,3,2). AᵀA = [[3,3],[3,3]] (singular!). This means columns are linearly dependent. The best fit is x₁ + x₂ = 2 (the average).

**P2:** Use normal equations for: A = [[1,1],[1,2],[1,3]], b = (1,2,2). Find x̂.
**Answer:** AᵀA = [[3,6],[6,14]], Aᵀb = [5,11]. Solving: 3x₁+6x₂=5, 6x₁+14x₂=11. x₂ = 1/2, x₁ = 2/3. Line: y = 2/3 + x/2.

**P3:** Why is minimizing ‖Ax − b‖² equivalent to projecting b onto C(A)?
**Answer:** The closest vector in C(A) to b is its projection. The projection Ax̂ minimizes distance ‖b − Ax‖, and squaring preserves the minimizer.

---

## VIDEO 17: W3_L5 — Example of Least Squares

### 📌 Key Concepts

**Fitting a Line y = C + Dt to Data:**
Given data points (t₁,y₁), (t₂,y₂), ..., (tₙ,yₙ):

Matrix form: A = [[1,t₁],[1,t₂],...,[1,tₙ]], x = [C,D]ᵀ, b = [y₁,...,yₙ]ᵀ

**Worked Example:**
Data: (0,6), (1,0), (2,0)

```
A = [[1,0],[1,1],[1,2]]    b = [6,0,0]

AᵀA = [[3,3],[3,5]]    Aᵀb = [6,0]

Solve: 3C + 3D = 6 and 3C + 5D = 0
→ 2D = −6 → D = −3, C = 5

Best fit line: y = 5 − 3t
```

**Residual Error:**
```
e = b − Ax̂ = [6,0,0] − [5,2,−1] = [1,−2,1]
‖e‖² = 1+4+1 = 6 (this is the minimum possible error)
```

**Fitting Higher-Order Polynomials:**
For y = a + bt + ct², use A with columns [1, t, t²].

### 🧮 Practice Problems

**P1:** Fit a line y = a + bt to points (1,1), (2,3), (3,2).
**Answer:** A = [[1,1],[1,2],[1,3]], b = [1,3,2]. AᵀA = [[3,6],[6,14]], Aᵀb = [6,13]. Solve: a = 2/3, b = 1/2. Line: y = 2/3 + t/2.

**P2:** For the fitted line in P1, compute the residual error vector and ‖e‖².
**Answer:** Predicted: [7/6, 5/3, 13/6]. Residuals: [1−7/6, 3−5/3, 2−13/6] = [−1/6, 4/3, −1/6]. ‖e‖² = 1/36+16/9+1/36 = 1/36+64/36+1/36 = 66/36 = 11/6.

**P3:** Why does adding more polynomial terms always reduce or maintain the training error?
**Answer:** Higher degree polynomials span a larger subspace. The projection onto a larger subspace is always at least as close to b as the projection onto a smaller subspace. So error can only decrease or stay the same.
