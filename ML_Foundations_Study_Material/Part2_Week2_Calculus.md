# 📘 Machine Learning Foundations — Study Material
# PART 2: WEEK 2 — CALCULUS FOUNDATIONS (Videos 7–12)

---

## VIDEO 7: W2_L1 — Sets & Functions

### 📌 Key Concepts

**Sets:** A collection of distinct objects. Notation: A = {1, 2, 3}

**Important Sets in ML:**
- ℕ = Natural numbers {0, 1, 2, ...}
- ℤ = Integers {..., −2, −1, 0, 1, 2, ...}
- ℝ = Real numbers (all points on the number line)
- ℝⁿ = n-dimensional real space (e.g., ℝ² = 2D plane)

**Set Operations:**
- **Union:** A ∪ B = elements in A or B (or both)
- **Intersection:** A ∩ B = elements in both A and B
- **Complement:** Aᶜ = elements NOT in A
- **Subset:** A ⊆ B if every element of A is in B

**Functions:**
A function f: A → B maps each element of domain A to exactly one element in codomain B.

**Properties of Functions:**
| Property | Definition | Example |
|----------|-----------|---------|
| Injective (1-to-1) | f(a) = f(b) ⟹ a = b | f(x) = 2x |
| Surjective (onto) | Every b ∈ B has some a with f(a) = b | f: ℝ → ℝ, f(x) = x³ |
| Bijective | Both injective and surjective | f(x) = 2x + 1 on ℝ |

**Composition:** (g ∘ f)(x) = g(f(x)) — apply f first, then g.

**Inverse Function:** If f is bijective, f⁻¹ exists such that f⁻¹(f(x)) = x.

### 🧮 Practice Problems

**P1:** Let A = {1,2,3,4,5}, B = {3,4,5,6,7}. Find A∪B, A∩B, A−B.
**Answer:** A∪B = {1,2,3,4,5,6,7}, A∩B = {3,4,5}, A−B = {1,2}

**P2:** Is f(x) = x² injective on ℝ? Is it surjective onto ℝ?
**Answer:** Not injective: f(2) = f(−2) = 4. Not surjective: no x gives f(x) = −1.

**P3:** Given f(x) = 3x + 1 and g(x) = x², find (g ∘ f)(2) and (f ∘ g)(2).
**Answer:** (g∘f)(2) = g(f(2)) = g(7) = 49. (f∘g)(2) = f(g(2)) = f(4) = 13.

**P4:** Find the inverse of f(x) = 5x − 3.
**Answer:** y = 5x − 3 → x = (y+3)/5 → f⁻¹(x) = (x+3)/5

---

## VIDEO 8: W2_L2 — Univariate Calculus: Continuity & Differentiability

### 📌 Key Concepts

**Limit:** lim(x→a) f(x) = L means as x approaches a, f(x) approaches L.

**Continuity:** f is continuous at x = a if:
1. f(a) is defined
2. lim(x→a) f(x) exists
3. lim(x→a) f(x) = f(a)

**Intuition:** You can draw the function without lifting your pen.

**Differentiability:** f is differentiable at x = a if this limit exists:
```
f'(a) = lim(h→0) [f(a+h) − f(a)] / h
```

**Key Relationship:** Differentiable at a ⟹ Continuous at a (but NOT vice versa!)
- Example: f(x) = |x| is continuous at x=0 but NOT differentiable (sharp corner).

**Basic Derivatives:**
| f(x) | f'(x) |
|-------|--------|
| c (constant) | 0 |
| xⁿ | nxⁿ⁻¹ |
| eˣ | eˣ |
| ln(x) | 1/x |
| sin(x) | cos(x) |
| cos(x) | −sin(x) |

### 🧮 Practice Problems

**P1:** Is f(x) = 1/x continuous at x = 0?
**Answer:** No. f(0) is undefined, so condition 1 fails.

**P2:** Using the limit definition, find the derivative of f(x) = x² at x = 3.
**Answer:** f'(3) = lim(h→0) [(3+h)² − 9]/h = lim(h→0) [9+6h+h²−9]/h = lim(h→0) (6+h) = 6.

**P3:** Is f(x) = |x − 2| differentiable at x = 2? Why?
**Answer:** No. The function has a sharp corner (kink) at x = 2. Left derivative = −1, right derivative = +1. Since they're not equal, derivative doesn't exist.

---

## VIDEO 9: W2_L3 — Univariate Calculus: Derivatives & Linear Approximations

### 📌 Key Concepts

**Derivative as Slope:** f'(a) gives the slope of the tangent line to f(x) at x = a.

**Linear Approximation (Tangent Line):**
```
f(x) ≈ f(a) + f'(a)(x − a)    (for x near a)
```
This is the best linear approximation of f near point a.

**Differentiation Rules:**
| Rule | Formula |
|------|---------|
| Sum | (f + g)' = f' + g' |
| Product | (fg)' = f'g + fg' |
| Quotient | (f/g)' = (f'g − fg')/g² |
| Chain | (f(g(x)))' = f'(g(x)) · g'(x) |

**Chain Rule — Most Important for ML!**
If y = f(g(x)), then dy/dx = (df/dg) · (dg/dx)

Example: y = (3x + 1)⁵  
Let u = 3x+1, y = u⁵  
dy/dx = 5u⁴ · 3 = 15(3x+1)⁴

### 🧮 Practice Problems

**P1:** Approximate √(4.1) using linear approximation of f(x) = √x near a = 4.
**Answer:** f(4) = 2, f'(x) = 1/(2√x), f'(4) = 1/4. So √(4.1) ≈ 2 + (1/4)(0.1) = 2.025. (Actual: 2.02485...)

**P2:** Find d/dx [x² · eˣ] using the product rule.
**Answer:** = 2x·eˣ + x²·eˣ = eˣ(x² + 2x)

**P3:** Find d/dx [sin(x²)] using the chain rule.
**Answer:** = cos(x²) · 2x = 2x·cos(x²)

**P4:** Find d/dx [(eˣ)/(x+1)] using the quotient rule.
**Answer:** = [eˣ(x+1) − eˣ·1]/(x+1)² = eˣ·x/(x+1)²

---

## VIDEO 10: W2_L4 — Univariate Calculus: Applications & Advanced Rules

### 📌 Key Concepts

**Finding Minima/Maxima (Critical Points):**
1. Find f'(x) = 0 → critical points
2. Second derivative test: f''(x) > 0 → minimum, f''(x) < 0 → maximum

**Why This Matters for ML:**
Optimization in ML = minimizing a loss function! We set the derivative of the loss to zero to find optimal parameters.

**Convexity:**
- f is **convex** if f''(x) ≥ 0 for all x (bowl-shaped)
- Convex functions have a **unique global minimum**
- MSE loss is convex → guaranteed to find the best solution!

**Taylor Series Expansion:**
```
f(x) = f(a) + f'(a)(x−a) + f''(a)(x−a)²/2! + f'''(a)(x−a)³/3! + ...
```
- First 2 terms = linear approximation
- More terms = better approximation

**Gradient Descent Preview:**
To minimize f(x):
```
x_new = x_old − α · f'(x_old)
```
Where α = learning rate (step size). This iteratively moves toward the minimum.

### 🧮 Practice Problems

**P1:** Find the minimum of f(x) = x² − 4x + 7.
**Answer:** f'(x) = 2x − 4 = 0 → x = 2. f''(x) = 2 > 0 → minimum. f(2) = 4−8+7 = 3. Minimum value is 3 at x = 2.

**P2:** Is f(x) = x³ convex? Why?
**Answer:** f''(x) = 6x. At x < 0, f''(x) < 0. Not always ≥ 0, so f(x) = x³ is NOT convex.

**P3:** Write the 2nd-order Taylor approximation of eˣ around a = 0.
**Answer:** f(0) = 1, f'(0) = 1, f''(0) = 1. So eˣ ≈ 1 + x + x²/2.

**P4:** Starting at x₀ = 5, perform one step of gradient descent on f(x) = (x−3)² with learning rate α = 0.1.
**Answer:** f'(x) = 2(x−3). f'(5) = 4. x₁ = 5 − 0.1(4) = 4.6. (Moving toward minimum at x=3 ✓)

---

## VIDEO 11: W2_L5 — Multivariate Calculus: Lines & Planes in Higher Dimensions

### 📌 Key Concepts

**Vectors in ℝⁿ:**
A vector v = (v₁, v₂, ..., vₙ) represents a direction and magnitude in n-dimensional space.

**Dot Product:** a · b = Σ aᵢbᵢ = |a||b|cos(θ)
- If a · b = 0, vectors are **orthogonal** (perpendicular)

**Lines in Higher Dimensions:**
A line through point p in direction d: L(t) = p + td, where t ∈ ℝ

**Planes in ℝ³ (and Hyperplanes in ℝⁿ):**
```
a₁x₁ + a₂x₂ + ... + aₙxₙ = b    (or nᵀx = b)
```
- n = (a₁, ..., aₙ) is the **normal vector** (perpendicular to the plane)
- **Hyperplane** in ℝⁿ divides space into two half-spaces

**Why This Matters for ML:**
- Linear classifiers create **hyperplanes** as decision boundaries
- A line/plane separating two classes: wᵀx + b = 0

**Partial Derivatives:**
For f(x₁, x₂, ..., xₙ), the partial derivative ∂f/∂xᵢ differentiates with respect to xᵢ treating all other variables as constants.

**Gradient Vector:**
```
∇f = (∂f/∂x₁, ∂f/∂x₂, ..., ∂f/∂xₙ)
```
The gradient points in the direction of **steepest increase** of f.

### 🧮 Practice Problems

**P1:** Find the equation of the plane with normal vector n = (1, 2, −1) passing through point (3, 0, 1).
**Answer:** 1(x−3) + 2(y−0) + (−1)(z−1) = 0 → x + 2y − z = 2.

**P2:** Find the gradient of f(x,y) = x²y + 3xy².
**Answer:** ∇f = (∂f/∂x, ∂f/∂y) = (2xy + 3y², x² + 6xy).

**P3:** Two vectors a = (1,2,3) and b = (3,0,−1). Are they orthogonal?
**Answer:** a·b = 3+0−3 = 0. Yes, they are orthogonal!

**P4:** Find the gradient of f(x,y) = x²+y² at point (3,4). What direction does it point?
**Answer:** ∇f = (2x, 2y). At (3,4): ∇f = (6,8). Points radially outward, direction of steepest ascent.

---

## VIDEO 12: W2_L6 — Multivariate Calculus: Linear Approximation & Applications

### 📌 Key Concepts

**Multivariate Linear Approximation:**
```
f(x) ≈ f(a) + ∇f(a)ᵀ(x − a)
```
This generalizes the tangent line to higher dimensions — a tangent plane!

**Gradient Descent in Multiple Dimensions:**
To minimize f(x₁, x₂, ..., xₙ):
```
x_new = x_old − α · ∇f(x_old)
```
We move in the direction **opposite** to the gradient (steepest descent).

**Hessian Matrix (Second-Order Info):**
The Hessian H is the matrix of second partial derivatives:
```
Hᵢⱼ = ∂²f / (∂xᵢ ∂xⱼ)
```
- If H is positive definite → local minimum
- If H is negative definite → local maximum
- Mixed signs → saddle point

**Critical Points in Multiple Dimensions:**
Set ∇f = 0 (the zero vector), then use the Hessian to classify.

**Application to ML:**
- Loss function L(w₁, w₂, ..., wₐ) depends on model weights
- Gradient descent updates ALL weights simultaneously:
  wᵢ ← wᵢ − α · (∂L/∂wᵢ)

### 🧮 Practice Problems

**P1:** Find the critical point(s) of f(x,y) = x² + y² − 2x − 4y + 8. Classify them.
**Answer:** ∇f = (2x−2, 2y−4) = (0,0) → x=1, y=2. H = [[2,0],[0,2]], positive definite → **minimum** at (1,2). f(1,2) = 1+4−2−8+8 = 3.

**P2:** Perform one gradient descent step on f(x,y) = x² + 4y² starting from (4,3) with α = 0.1.
**Answer:** ∇f = (2x, 8y). At (4,3): ∇f = (8, 24). New point: (4−0.8, 3−2.4) = (3.2, 0.6).

**P3:** Find the Hessian of f(x,y) = x³ + xy² − 3x.
**Answer:** ∂f/∂x = 3x²+y²−3, ∂f/∂y = 2xy. H = [[6x, 2y],[2y, 2x]].

**P4:** Why does gradient descent use the NEGATIVE gradient direction?
**Answer:** The gradient ∇f points toward steepest increase. To minimize f, we go the opposite way (steepest decrease), hence the negative sign: x ← x − α∇f.
