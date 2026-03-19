# 📘 Machine Learning Foundations — Study Material
# PART 5: WEEK 1 TUTORIALS (Videos 22–24)

---

## VIDEO 22: W1_T1 — To Machine Learning or Not to Machine Learning

### 📌 Key Concepts

**When to Use ML:**
- ✅ Pattern is too complex for manual rules
- ✅ Large amounts of data available
- ✅ Pattern changes over time (adaptable models)
- ✅ Problem requires personalization at scale

**When NOT to Use ML:**
- ❌ Simple, well-defined rules exist (e.g., calculating tax)
- ❌ Insufficient data
- ❌ Results must be 100% explainable/deterministic (legal/critical systems)
- ❌ Cost of errors is extremely high with no fallback

**Decision Framework:**
```
1. Is there a pattern to learn?           → No: Don't use ML
2. Can you define the pattern manually?   → Yes: Consider rules first
3. Do you have enough data?               → No: Collect more or use simple models
4. Does the pattern change over time?     → Yes: ML is ideal
```

**Common Pitfalls:**
- Using ML when a simple formula works
- Not having enough labeled data for supervised learning
- Ignoring data quality (garbage in = garbage out)
- Choosing overly complex models for simple problems

### 🧮 Practice Problems

**P1:** For each scenario, decide "ML" or "No ML" with justification:
- (a) Converting temperature from Celsius to Fahrenheit
- (b) Detecting fraudulent credit card transactions
- (c) Recommending movies based on viewing history
- (d) Calculating compound interest

**Answers:**
- (a) No ML — exact formula: F = 9C/5 + 32
- (b) ML — complex patterns, evolving fraud techniques
- (c) ML — personalization from millions of users' data
- (d) No ML — exact formula: A = P(1+r)ⁿ

**P2:** A hospital wants to predict patient readmission. They have 50 records. Should they use deep learning?
**Answer:** No. Deep learning requires thousands/millions of examples. With only 50 records, use simpler models (logistic regression, decision trees) or collect more data.

---

## VIDEO 23: W1_T2 — Illustration with a Real-World Dataset

### 📌 Key Concepts

**The ML Workflow in Practice:**

**Step 1 — Data Loading:**
Load data from CSV, database, or API. Inspect shape, types, missing values.

**Step 2 — Exploratory Data Analysis (EDA):**
- Summary statistics (mean, median, std, min, max)
- Histograms: distribution of each feature
- Scatter plots: relationships between features and target
- Correlation matrix: identify redundant features

**Step 3 — Data Preprocessing:**
- Handle missing values (impute or drop)
- Feature scaling: normalize (0-1) or standardize (mean=0, std=1)
- Encoding categorical variables (one-hot encoding)
- Train-test split (e.g., 80-20)

**Step 4 — Model Training:**
- Choose a model (start simple: linear regression)
- Fit on training data
- Tune hyperparameters using validation set

**Step 5 — Evaluation:**
- Predict on test set
- Compute metrics (MSE, R², accuracy, etc.)
- Analyze residuals — look for patterns in errors

**Feature Scaling — Why It Matters:**
If Feature A is in range [0, 1] and Feature B is in [0, 1000000], Feature B would dominate distance calculations. Scaling puts them on equal footing.

| Method | Formula | Result Range |
|--------|---------|-------------|
| Min-Max | (x − min)/(max − min) | [0, 1] |
| Standardization | (x − μ)/σ | mean=0, std=1 |

### 🧮 Practice Problems

**P1:** Given data: [10, 20, 30, 40, 50]. Apply Min-Max normalization.
**Answer:** min=10, max=50, range=40. Normalized: [0, 0.25, 0.5, 0.75, 1.0]

**P2:** Given data: [2, 4, 4, 4, 5, 5, 7, 9]. Apply Z-score standardization.
**Answer:** μ=5, σ=2. Standardized: [−1.5, −0.5, −0.5, −0.5, 0, 0, 1, 2]

**P3:** You have 10,000 data points with 3% missing values in one column. Should you drop rows or impute?
**Answer:** Impute. Dropping would lose ~300 data points unnecessarily. Use mean/median imputation or more sophisticated methods (KNN imputation).

**P4:** Why should you split data BEFORE feature scaling?
**Answer:** If you scale before splitting, the test set mean/std leaks into the training process (data leakage). Scale using ONLY training set statistics, then apply the SAME transformation to the test set.

---

## VIDEO 24: W1_T3 — Dimensionality Reduction & Density Estimation with Applications

### 📌 Key Concepts

**PCA in Practice:**
1. Center the data (subtract column means)
2. Compute covariance matrix Σ = (1/n)XᵀX
3. Find eigenvalues and eigenvectors of Σ
4. Sort by eigenvalue magnitude (largest first)
5. Choose k components (use scree plot or variance threshold)
6. Project: X_new = X × V_k (where V_k has top-k eigenvectors as columns)

**Scree Plot:** Plot eigenvalues vs component number. Look for the "elbow" — where eigenvalues drop significantly. Components before the elbow are kept.

**Choosing k:**
- Method 1: Keep components until 90-95% variance is explained
- Method 2: Elbow in scree plot
- Method 3: Kaiser criterion — keep eigenvalues > 1 (for standardized data)

**Density Estimation Applications:**

**Anomaly Detection Pipeline:**
1. Fit a density model (Gaussian or KDE) to normal data
2. For a new point x, compute p(x)
3. If p(x) < threshold → flag as anomaly

**Naive Bayes Classifier (connects density estimation to classification):**
```
P(class | x) ∝ P(x | class) × P(class)
```
- P(x | class) = estimated density for each class
- Simple but effective for text classification (spam filtering)

**Multivariate Gaussian for Anomaly Detection:**
Fit μ and Σ to data. For new point x:
```
p(x) = (1/((2π)^(d/2)|Σ|^(1/2))) exp(−½(x−μ)ᵀΣ⁻¹(x−μ))
```
If p(x) < ε (threshold), mark as anomaly.

### 🧮 Practice Problems

**P1:** Eigenvalues of a covariance matrix: [4.5, 2.1, 0.8, 0.4, 0.2]. What % variance does keeping 2 components capture?
**Answer:** Total = 4.5+2.1+0.8+0.4+0.2 = 8.0. Top 2 = 4.5+2.1 = 6.6. Percentage = 6.6/8.0 = 82.5%.

**P2:** You run PCA on 100-dimensional data and find that 5 components explain 98% of variance. What happened?
**Answer:** The data lies close to a 5-dimensional subspace within the 100-dimensional space. Most features are highly correlated or redundant. PCA reveals the intrinsic dimensionality is ~5.

**P3:** In anomaly detection using Gaussian density, your fitted model has μ=(0,0) and Σ=[[1,0],[0,1]]. Is the point (5,5) anomalous?
**Answer:** (x−μ)ᵀΣ⁻¹(x−μ) = 5²+5² = 50. This is the squared Mahalanobis distance. For a 2D Gaussian, values above ~6 correspond to < 5% probability. 50 is extremely far out → **highly anomalous**.

**P4:** Why might KDE be preferred over Gaussian density estimation for anomaly detection?
**Answer:** If the true density is multi-modal (has multiple peaks/clusters), a single Gaussian cannot capture it. KDE makes no assumptions about shape and can model arbitrary distributions. However, KDE suffers in high dimensions (curse of dimensionality).

---

# 📊 QUICK REFERENCE: FULL COURSE TOPIC MAP

| Video | Week | Topic | Key Formulas |
|-------|------|-------|-------------|
| 1 | W1 | What is ML? | Mitchell's Definition |
| 2 | W1 | Data, Models, ML Task | X ∈ ℝⁿˣᵈ |
| 3 | W1 | Regression | MSE = (1/n)Σ(y−ŷ)² |
| 4 | W1 | Classification | Precision, Recall, F1 |
| 5 | W1 | Dimensionality Reduction | PCA, Variance Explained |
| 6 | W1 | Density Estimation | Gaussian p(x), KDE |
| 7 | W2 | Sets & Functions | Injective, Surjective, Bijective |
| 8 | W2 | Continuity & Differentiability | f'(a) = lim definition |
| 9 | W2 | Derivatives & Linear Approx | Chain, Product, Quotient rules |
| 10 | W2 | Applications & Advanced Rules | Optimization, Convexity, Taylor |
| 11 | W2 | Lines & Planes in ℝⁿ | Gradient ∇f, Hyperplanes |
| 12 | W2 | Multivariate Linear Approx | Gradient Descent, Hessian |
| 13 | W3 | Four Fundamental Subspaces | C(A), N(A), rank-nullity |
| 14 | W3 | Orthogonal Vectors | Gram-Schmidt, QR |
| 15 | W3 | Projections | P = aaᵀ/(aᵀa) |
| 16 | W3 | Least Squares | AᵀAx̂ = Aᵀb |
| 17 | W3 | Least Squares Example | Line fitting |
| 18 | W4 | Eigenvalues & Eigenvectors | det(A−λI) = 0 |
| 19 | W4 | Diagonalization | A = SΛS⁻¹ |
| 20 | W4 | Fibonacci via Diagonalization | Binet's Formula |
| 21 | W4 | Orthogonal Diagonalization | Spectral Theorem, A = QΛQᵀ |
| 22 | W1T | When to Use ML? | Decision framework |
| 23 | W1T | Real-World Dataset | EDA, Preprocessing |
| 24 | W1T | PCA & Density Applications | Scree plot, Anomaly Detection |
