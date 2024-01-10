---
Title: 特征工程
Author: Blackteaxx
Description: 没想好，让我想想
---

# 特征工程

# 0. 数据探索

## 0.1 数据正确性校验

ID 是否唯一，字段类型是否合规

- 检查重复值

python

```{python}
# 检查主键
df["colname"].nunique() == df.shape[0]

# 检查重复行
df.duplicated().sum()
```

R

```{r}
any(duplicated(df$x))

any(duplicated(df))

```

- 缺失值检验

缺失值有很多种：NaN、None、NULL、NA...
或者是数据产出的时候自定义的

python

```{python}
df.isnull().sum()
```

R

```{r}
# 检查每一列的缺失值
missing_values <- colSums(is.na(df))

# 计算每一列缺失值的占比
missing_percentages <- missing_values / nrow(df) * 100

# 输出每一列缺失值的占比
missing_percentages
```

## 1. 数据预处理

### 1.1 数据重编码

编码格式不对，数值转化，量纲不一致

- 1. OneHotEncoder 独热编码（即哑变量/分类变量转化）

对于二分类而言，独热编码转化没什么实际作用

python

```{python}
from sklearn import preprocessing
enc = preprocessing.OneHotEncoder()
enc.fit_transform(X1).toarray()

enc.categories_
```

R

```{r}
你猜R要不要考虑这些
不用啦，直接as.factor()就行，模型都帮你做好了独热编码
```

- 2. 连续变量离散化：分箱

  - Q：分箱损失了信息，那为什么需要处理？
  - A：

    - 消除量纲影响，并且能够处理离群值（极端值）
    - 简介呈现特征信息，比较好解释
    - **在线性模型中加入了非线性因素，跟激活/Sigmoid 函数有点类似的效果，即防止线性叠加还是线性**，在**逻辑回归**里分箱效果会好，但是在树模型当中损失的信息可能会极大的影响模型结果。

  - 2.1 等宽分箱

```{python}
dis = preprocessing.KBinsDiscretizer(n_bins=3, encode="ordinary",strategy="uniform")

dis.fit_transform(col)
dis.bins_
```

  - 2.2 分位数分箱

  - 2.3 聚类分箱

    一定程度上保留异常值的信息，能够更完整保留原始数值分布

```{python}
from sklearn import cluster
kmeans = cluster.KMeans(n_clusters=3)
kmeans.fit(col)
kmeans.labels_
```

```{python}
dis = preprocessing.KBinsDiscretizer(n_bins=3, encode="ordinary",strategy="kmeans")
```

### 1.2 样本不平衡

样本分布不均匀

### 1.3 缺失值/异常值

## 2. 特征衍生

### 2.1 手动特征衍生

### 2.2 批量特征衍生

批量生成成批次变量，喂给集成算法

- 分组统计特征衍生

  - 根据离散变量的分组来统计连续变量/离散变量的统计量

  - 分组的特征最好是取值较多的变量，不然会出现重复的行

  - 统计量：mean/var/max/min/skew

- 时序

## 3. 特征筛选

过滤法、包裹法、嵌入法