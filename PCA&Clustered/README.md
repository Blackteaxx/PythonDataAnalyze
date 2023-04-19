# Preview on DataSet

## 1. 我们的目标是什么

在一个没有标注垃圾评论信息的 youtube 评论数据集上，我们需要构建一些特征，并使用无监督算法找出可能是垃圾评论的那些数据。

**此处的重点是：如何定义垃圾评论，即如何用人类自然语言的标准来标注垃圾评论**

## 2. 原数据集长什么样子

| 字段名           | 字段含义 |
| ---------------- | -------- |
| User             | Up 主    |
| Video Title      | 视频标题 |
| Comment (Actual) | 评论内容 |
| Comment Author   | 评论用户 |

## 3. 我们构建了什么特征，以及为什么这么构建

| 特征名                | 特征含义                   |
| --------------------- | -------------------------- |
| Comment Author Counts | 用户在本数据集中评论的次数 |
| Polarity              | 评论的情感极性             |
| Comment Length        | 评论长度                   |
| Worth Word Ratio      | 有用词性占比               |
| PCA1 & 2 & 3          | 语义数值向量               |

### 3.1 Comment Author Counts

pass

### 3.2 Polarity

pass

### 3.3 Comment Length

pass

### 3.4 Worth Word Ratio

pass

### 3.5 PCA 1 & 2 & 3

语句语义向量化有很多种方式，我这里选择的是 Bert-Whitening + PCA

> 用 BERT 模型生成向量的原理是基于 pooling 操作，即对 BERT 模型最后一层输出执行池化操作得到文本的向量表示。
> 具体地说，在 BERT 模型中，每个输入序列（例如单个句子或多个句子）都被编码为一个固定长度的向量序列。对于每个位置 i，BERT 模型会输出一个大小为 hidden_size 的向量 hi，其中 hidden_size 是预训练模型的隐藏状态大小。
> 因此，我们可以将 BERT 模型的输出视为一个形状为(batch_size, seq_len, hidden_size)的张量，其中 batch_size 是批次大小，seq_len 是最大序列长度，hidden_size 是模型的隐藏状态大小。
> 在第二种方法中，为了将整个输入文本表示为单个向量，可以通过在最后一层隐藏状态上执行平均池化（mean pooling）或最大池化（max pooling）等操作来组合所有单词向量。常用的是平均池化，即将所有单词向量的值相加并除以总数，得到一个平均向量作为文本的向量表示。这样得到的向量就可以代表输入文本，并输入到下游任务中进行分类、聚类等操作。
> 需要注意的是，由于 BERT 模型对于长序列的处理能力较强，因此在使用第二种方法时，可以选择保留较长的序列，以充分利用 BERT 模型的能力。同时，还需要根据具体情况选择合适的池化方式和向量维度大小。

Bert-Whitening 最后得出了 750+特征，根据方差（threshold = 0.1）与 PCA（threshold = 0.95）最终选出 3 个特征作为代表语义的向量
