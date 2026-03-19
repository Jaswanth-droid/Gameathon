# 📘 Machine Learning Foundations — Study Material
# PART 1: WEEK 1 — LECTURES (Videos 1–6)

---

## VIDEO 1: W1.L1 — What is Machine Learning? | Intro to ML & Its Applications

### 📌 Key Concepts

**What is Machine Learning?**
Machine Learning (ML) is a branch of Artificial Intelligence where computers learn patterns from data without being explicitly programmed. Instead of writing rules manually, we feed data to algorithms that discover the rules themselves.

> **Arthur Samuel (1959):** "Machine Learning is the field of study that gives computers the ability to learn without being explicitly programmed."

> **Tom Mitchell (1997):** "A computer program is said to learn from experience E with respect to some task T and some performance measure P, if its performance on T, as measured by P, improves with experience E."

**Why ML?**
- Too many rules to write manually (e.g., spam detection — thousands of spam patterns)
- Patterns change over time (e.g., fraud detection — attackers adapt)
- Data is too complex for humans (e.g., medical imaging, genome analysis)
- Scales to massive datasets (e.g., recommendation systems for millions of users)

**Types of Machine Learning:**

| Type | Input | Output | Example |
|------|-------|--------|---------|
| Supervised | Data + Labels | Prediction model | Email → Spam/Not Spam |
| Unsupervised | Data (no labels) | Patterns/Structure | Customer segmentation |
| Reinforcement | Environment + Rewards | Policy/Strategy | Game-playing AI |

**Real-World Applications:**
- **Image Recognition:** Face detection, medical X-ray analysis
- **NLP:** Chatbots, translation, sentiment analysis
- **Recommendation Systems:** Netflix, YouTube, Amazon
- **Self-driving Cars:** Object detection, path planning
- **Finance:** Stock prediction, credit scoring, fraud detection

### 🧮 Practice Problems

**Problem 1:** Classify whether each scenario is supervised, unsupervised, or reinforcement learning:
- (a) Grouping news articles into topics without predefined categories
- (b) Training a robot to walk by rewarding it for staying upright
- (c) Predicting house prices from historical sales data
- (d) Finding unusual transactions in credit card data

**Answers:**
- (a) Unsupervised (clustering)
- (b) Reinforcement Learning
- (c) Supervised (regression)
- (d) Unsupervised (anomaly detection)

**Problem 2:** For each application, identify T (task), P (performance), E (experience) using Mitchell's definition:
- Playing chess: T = Playing chess, E = Games played, P = Win rate
- Email filtering: T = Classify email, E = Labeled email dataset, P = Classification accuracy

**Problem 3:** Why can't we just use traditional programming (if-else rules) for face recognition? Explain in 3 points.

**Answer:** (1) Faces vary in lighting, angle, expression — too many variations to hard-code. (2) Rules would need to capture millions of pixel patterns. (3) New faces require the system to generalize, not just memorize.

---

## VIDEO 2: W1_L2 — Data, Models & Machine Learning Task

### 📌 Key Concepts

**Data Representation:**
Data in ML is represented as a matrix where:
- Each **row** = one data point (sample/instance)
- Each **column** = one feature (attribute/variable)
- The matrix is called the **design matrix** or **feature matrix** X ∈ ℝⁿˣᵈ (n samples, d features)

**Example:**
| Height (cm) | Weight (kg) | Age | Label |
|-------------|-------------|-----|-------|
| 170 | 65 | 25 | Healthy |
| 155 | 80 | 45 | At Risk |

Here: n = 2 (samples), d = 3 (features), y = label column

**What is a Model?**
A model is a mathematical function f(x) that maps inputs to outputs:
- **Linear model:** f(x) = w₁x₁ + w₂x₂ + ... + wₐxₐ + b
- **Polynomial model:** f(x) = w₁x + w₂x² + ... + wₙxⁿ + b
- The goal: find the best parameters (weights w, bias b) that minimize prediction error

**The ML Pipeline:**
```
Raw Data → Preprocessing → Feature Extraction → Model Training → Evaluation → Deployment
```

**Training vs Testing:**
- **Training set:** Data used to learn the model parameters (70-80% of data)
- **Test set:** Held-out data to evaluate how well the model generalizes (20-30%)
- **Validation set:** Used to tune hyperparameters (optional, carved from training set)

**Overfitting vs Underfitting:**
- **Overfitting:** Model memorizes training data, fails on new data (too complex)
- **Underfitting:** Model is too simple, fails on both training and test data
- **Goal:** Find the sweet spot (bias-variance tradeoff)

### 🧮 Practice Problems

**Problem 1:** Given a dataset with 1000 samples and 5 features, what is the shape of the design matrix X?
**Answer:** X ∈ ℝ^(1000×5) — 1000 rows, 5 columns.

**Problem 2:** You have a model that achieves 99% accuracy on training data but only 55% on test data. What is the problem? How would you fix it?
**Answer:** Overfitting. Fix: (1) Get more training data, (2) Use regularization, (3) Reduce model complexity, (4) Use cross-validation.

**Problem 3:** Arrange the ML pipeline steps in correct order: Evaluation, Feature Extraction, Model Training, Preprocessing, Data Collection.
**Answer:** Data Collection → Preprocessing → Feature Extraction → Model Training → Evaluation.

**Problem 4:** If you have 500 data points, how would you split them for training, validation, and testing?
**Answer:** Common split: 350 training (70%), 75 validation (15%), 75 testing (15%).

---

## VIDEO 3: W1_L3 — Supervised Learning: Regression

### 📌 Key Concepts

**What is Regression?**
Regression predicts a **continuous** numerical output. The target variable y ∈ ℝ (real number).

**Linear Regression:**
The simplest regression model assumes a linear relationship:
```
f(x) = w₁x₁ + w₂x₂ + ... + wₐxₐ + b = wᵀx + b
```

**Loss Function (Mean Squared Error):**
We want to minimize the error between predictions and actual values:
```
MSE = (1/n) Σᵢ (yᵢ − f(xᵢ))²
```

**Why Squared Error?**
- Penalizes large errors more than small ones
- Is differentiable (allows gradient-based optimization)
- Has a unique minimum (convex function)

**Polynomial Regression:**
When data isn't linear, we can fit higher-degree polynomials:
```
f(x) = w₀ + w₁x + w₂x² + w₃x³ + ...
```
⚠️ Higher degree = more flexibility but higher risk of overfitting.

**Evaluation Metrics for Regression:**
| Metric | Formula | Interpretation |
|--------|---------|----------------|
| MSE | (1/n) Σ(yᵢ - ŷᵢ)² | Average squared error |
| RMSE | √MSE | Error in same units as y |
| MAE | (1/n) Σ|yᵢ - ŷᵢ| | Average absolute error |
| R² Score | 1 - (SS_res / SS_tot) | % of variance explained (0-1) |

### 🧮 Practice Problems

**Problem 1:** Given points: (1, 2), (2, 4), (3, 5), (4, 4), (5, 5). Fit a line y = wx + b.
Using normal equations: w = 0.6, b = 2.2 → y = 0.6x + 2.2

**Problem 2:** Calculate MSE for the predictions: Actual = [3, 5, 2, 7], Predicted = [2.5, 5.5, 1.5, 6].
**Answer:** MSE = [(0.5)² + (0.5)² + (0.5)² + (1)²] / 4 = [0.25 + 0.25 + 0.25 + 1] / 4 = 1.75/4 = 0.4375

**Problem 3:** Why would you use MAE instead of MSE?
**Answer:** MAE is more robust to outliers because it doesn't square the errors. If your data has extreme outliers, MAE gives a more realistic error estimate.

**Problem 4:** A model has R² = 0.85. Interpret this.
**Answer:** The model explains 85% of the variance in the target variable. 15% of variance is unexplained.

---

## VIDEO 4: W1_L4 — Supervised Learning: Classification

### 📌 Key Concepts

**What is Classification?**
Classification predicts a **discrete** categorical output. The target y ∈ {0, 1} (binary) or {1, 2, ..., K} (multi-class).

**Examples:**
- Email: Spam (1) or Not Spam (0)
- Medical: Disease present or absent
- Image: Cat, Dog, Bird (multi-class)

**Decision Boundary:**
A classification model learns a boundary that separates classes in feature space.
- **Linear classifier:** Separates with a straight line/plane
- **Non-linear classifier:** Separates with curves/complex shapes

**Nearest Neighbor Classifier:**
- For a new point, find the K closest training points
- Assign the majority class among those K neighbors
- K is a hyperparameter (K=1: very flexible, K=large: smoother boundary)

**Evaluation Metrics for Classification:**

| Metric | Formula | Use When |
|--------|---------|----------|
| Accuracy | (TP+TN)/(TP+TN+FP+FN) | Balanced classes |
| Precision | TP/(TP+FP) | Cost of false positives is high |
| Recall | TP/(TP+FN) | Cost of missing positives is high |
| F1 Score | 2·(P·R)/(P+R) | Balance precision & recall |

**Confusion Matrix:**
```
                Predicted Positive  Predicted Negative
Actual Positive      TP                   FN
Actual Negative      FP                   TN
```

### 🧮 Practice Problems

**Problem 1:** Given a confusion matrix: TP=80, FP=10, FN=15, TN=95. Calculate Accuracy, Precision, Recall, F1.
**Answer:**
- Accuracy = (80+95)/(80+10+15+95) = 175/200 = 0.875 = 87.5%
- Precision = 80/(80+10) = 80/90 = 0.889 = 88.9%
- Recall = 80/(80+15) = 80/95 = 0.842 = 84.2%
- F1 = 2(0.889 × 0.842)/(0.889 + 0.842) = 1.497/1.731 = 0.865 = 86.5%

**Problem 2:** In a cancer detection system, which is worse — a false positive or a false negative? Which metric should you prioritize?
**Answer:** False negative (missing actual cancer) is worse. Prioritize **Recall** to minimize missed cases.

**Problem 3:** In KNN with K=1, you have training points A(1,1)=Red, B(3,3)=Blue, C(2,1)=Red. Classify point P(2,2).
**Answer:** Distances: d(P,A) = √2 ≈ 1.41, d(P,B) = √2 ≈ 1.41, d(P,C) = 1. Nearest is C (Red). Classification: **Red**.

---

## VIDEO 5: W1_L5 — Unsupervised Learning: Dimensionality Reduction

### 📌 Key Concepts

**What is Dimensionality Reduction?**
Reducing the number of features (dimensions) while preserving as much information as possible.

**Why Reduce Dimensions?**
- **Curse of dimensionality:** More features → need exponentially more data
- **Visualization:** Can only visualize 2D or 3D
- **Speed:** Fewer features = faster training
- **Noise removal:** Remove redundant/noisy features

**Principal Component Analysis (PCA) — Intuition:**
PCA finds new axes (principal components) that capture maximum variance in the data.

1. **Step 1:** Center the data (subtract mean)
2. **Step 2:** Compute the covariance matrix
3. **Step 3:** Find eigenvectors & eigenvalues of the covariance matrix
4. **Step 4:** Sort eigenvectors by eigenvalues (largest first)
5. **Step 5:** Choose top-k eigenvectors → these are your new axes
6. **Step 6:** Project data onto these k axes

**Key Insight:** The first principal component captures the direction of maximum variance. The second captures the most variance orthogonal to the first, and so on.

**Variance Explained:**
If eigenvalues are λ₁ ≥ λ₂ ≥ ... ≥ λₐ, the fraction of variance explained by first k components:
```
Variance explained = (λ₁ + λ₂ + ... + λₖ) / (λ₁ + λ₂ + ... + λₐ)
```

### 🧮 Practice Problems

**Problem 1:** You have a 1000-dimensional dataset. PCA gives eigenvalues where the top 10 explain 95% of variance. How many dimensions should you keep?
**Answer:** Keep 10 dimensions. This reduces from 1000 to 10 features while retaining 95% of the information.

**Problem 2:** Why must we center the data before PCA?
**Answer:** PCA finds directions of maximum variance. Without centering, the mean offset would dominate, and PCA would find axes biased toward the mean rather than the true variance directions.

**Problem 3:** Given 2D data points (1,2), (3,4), (5,6), what direction does PC1 point?
**Answer:** The data lies roughly on the line y = x + 1. PC1 points along direction (1/√2, 1/√2) — the 45° diagonal, capturing maximum spread.

---

## VIDEO 6: W1_L6 — Unsupervised Learning: Density Estimation

### 📌 Key Concepts

**What is Density Estimation?**
Estimating the probability distribution p(x) that generated the data. We want to know: "How likely is a new data point under this distribution?"

**Why Density Estimation?**
- Anomaly detection (unlikely points = anomalies)
- Data generation (sample new points from the estimated distribution)
- Understanding data distribution

**Parametric vs Non-Parametric:**

| Approach | Assumption | Example |
|----------|-----------|---------|
| Parametric | Data follows a known distribution form | Fit a Gaussian: estimate μ and σ² |
| Non-parametric | No assumption on distribution form | Kernel Density Estimation (KDE) |

**Gaussian (Normal) Distribution:**
```
p(x) = (1 / √(2πσ²)) · exp(−(x − μ)² / (2σ²))
```
- μ = mean (center), σ² = variance (spread)
- Estimate from data: μ̂ = (1/n)Σxᵢ, σ̂² = (1/n)Σ(xᵢ − μ̂)²

**Multivariate Gaussian:**
```
p(x) = (1 / ((2π)^(d/2) |Σ|^(1/2))) · exp(−½(x − μ)ᵀ Σ⁻¹ (x − μ))
```
Where Σ is the covariance matrix (d×d).

**Kernel Density Estimation (KDE):**
Place a "kernel" (e.g., Gaussian bump) on each data point, sum them up:
```
p̂(x) = (1/nh) Σᵢ K((x − xᵢ)/h)
```
- h = bandwidth (controls smoothness)
- Small h → jagged estimate (overfitting)
- Large h → overly smooth (underfitting)

### 🧮 Practice Problems

**Problem 1:** Given data points: 2, 4, 4, 4, 5, 5, 7, 9. Estimate the Gaussian parameters μ and σ².
**Answer:** μ = (2+4+4+4+5+5+7+9)/8 = 40/8 = 5.0. σ² = [(−3)²+(−1)²+(−1)²+(−1)²+0²+0²+2²+4²]/8 = [9+1+1+1+0+0+4+16]/8 = 32/8 = 4.0

**Problem 2:** A fitted Gaussian has μ=50, σ=10. A new data point x=90 is observed. Is it likely an anomaly?
**Answer:** x is 4σ away from the mean (z-score = 4). The probability of being ≥4σ from the mean is ~0.006%. Yes, very likely an anomaly.

**Problem 3:** In KDE, what happens if bandwidth h → 0? What if h → ∞?
**Answer:** h → 0: Each point becomes a spike, density is very jagged (overfits). h → ∞: The density becomes a single flat bump centered at the mean (underfits, loses all structure).
