## 简介

此数据集总结了 Mashable 在两年内发表的文章的一组异质特征。目标是预测社交网络（人气）的份额数量。

数据
这些文章由 Mashable（www.mashable.com）出版，其内容作为复制权属于他们。因此，此数据集不共享原始内容，而是共享与它相关的一些统计数据。使用提供的网址公开访问和检索原始内容。

收购日期：2015 年 1 月 8 日

作者使用随机森林分类器和滚动窗口作为评估方法估计了估计的相对性能值。有关相对性能值的设置方式，请参阅他们的文章以了解更多详细信息。

## 数据字典

| 数据项                        | 数据含义                                             |
| ----------------------------- | ---------------------------------------------------- |
| url                           | 就作为主键吧..                                       |
| title                         |                                                      |
| content                       |                                                      |
| **日期**                      |                                                      |
| timedelta                     | 距离收集时间的间隔                                   |
| Date                          | 日期                                                 |
| weekday_is_monday             |                                                      |
| weekday_is_tuesday            |                                                      |
| weekday_is_wednesday          |                                                      |
| weekday_is_thursday           |                                                      |
| weekday_is_friday             |                                                      |
| weekday_is_saturday           |                                                      |
| weekday_is_sunday             |                                                      |
| is_weekend                    |                                                      |
| isHoliday                     | 是否是节假日                                         |
| HolidayName                   | 如果是节假日，节假日名称（Not Holiday）              |
| HolidayDay                    | 如果是节假日，是节假日的第几天                       |
| HolidayDaysLeft               | 如果是节假日，距离节假日结束还有几天（最后一天算 1） |
| dayRatio                      | 昨天的热度相对于前天的热度的增长率(以此类推)         |
| threeDayRatio                 |                                                      |
| weekRatio                     |                                                      |
| twoWeekRatio                  |                                                      |
| **描述性特征**                |                                                      |
| n_tokens_title                | 标题字数                                             |
| n_tokens_content              | 正文有多少字                                         |
| n_unique_tokens               | 正文不同字数占比                                     |
| n_non_stop_words              | 正文非停用词占比                                     |
| n_non_stop_unique_tokens      | 正文非停用词不同字数占比（这个不确定）               |
| num_hrefs                     | 外链个数                                             |
| num_self_hrefs                | 自链个数                                             |
| num_imgs                      | 图片个数                                             |
| num_videos                    | 视频个数                                             |
| average_token_length          |                                                      |
| data_channel_is_lifestyle     |                                                      |
| data_channel_is_entertainment |                                                      |
| data_channel_is_bus           |                                                      |
| data_channel_is_socmed        |                                                      |
| data_channel_is_tech          |                                                      |
| data_channel_is_world         |                                                      |
| topicNo                       | LDA 主题所属类                                       |
| **标题**                      |                                                      |
| Comparatives Count            | 标题比较级个数                                       |
| Superlatives Count            | 标题最高级个数                                       |
| Count Intensifiers            | 标题强化词个数                                       |
| Count Downtoners              | 标题弱化词个数                                       |
| Flesch Kincaid Grade of Title | 标题可读性指数（简洁性）                             |
| SyntaxTree Height             | 标题语法分析树高度（简洁性）                         |
| All Possible Meanings         | 标题所有可能意思（歧义）                             |
| novel of title                | 1- 和在它之前的 tf-idf 余弦相似度最大值（新奇性）    |
| noun_count                    | 标题名词个数                                         |
| verb_count                    | 标题动词个数                                         |
| adverb_count                  | 标题副词个数                                         |
| punc_count                    | 标题！，？个数                                       |
| title_subjectivity            | 标题客观性                                           |
| title_sentiment_polarity      | 标题情感极性                                         |
| **文章**                      |                                                      |
| ContentFleschReadingEase      | 可读性                                               |
| NWordRatio                    | 名词占比                                             |
| JWordRatio                    | 形容词占比                                           |
| VWordRatio                    | 动词占比                                             |
| wordRatioIn8000               | 在 8000 词的词的占比                                 |
| global_subjectivity           | 文章的主观程度                                       |
| globalsentimentpolarity       | 文章的情感极性                                       |
| globalratepositive_words      | 积极词的占比                                         |
| globalratenegative_words      | 消极词的占比                                         |
| ratepositivewords             | 非中性词积极词的占比                                 |

## 特征构建

第一个任务，我们需要构建很多很多特征，并对结果进行解释。我想用的回归树模型，因为比较好可视化，同时解释性也比较好。

突发热点

- 内容

  - 维基实体上的序贯特征

- 时间

  - Based：日期

  - Based：距离收集日期的天数

  - Based：周几

  - Extended：是否处于节假日？处于节假日的第几天？

- 文本

  - 标题

    - Based：标题中实体文本（名词）

      - WikiEntity

    - 简洁性

      - Based：标题字数

      - Extended：可读性指标？

        - Flesch Kincaid Grade of Title

      - 语法树深度（从句）

        - SyntaxTree Height

        [解决方案](https://flowus.cn/74a2f707-4709-4b76-93ea-3da9679c42b9)

    - 新奇性

      - 语言上的

        - Extended：修辞（比喻）

        - 表达上的相似度，可以用词袋聚类，也可以用 tf-idf 聚类选取时间最先的那个

      - 内容上的

        - 数据集内独特性：标题所含实体根据时序在 1 天，5 天，10 天 前是否有重复出现

        - 一些标题内的实体在热度上的时序特征：实体在 1 天，5 天，10 天前维基热度（谷歌搜索指数）指标

        - 规模：

          - 比较级与最高级词语的比例

            - Comparatives Count

            - Superlatives Count

          - intensifiers（强化词）的比例

            - Count Intensifiers

          - downtoner（弱化词）的比例

            - Count Downtoners

    - 歧义

      - All Possible Meanings

      [词汇消歧法](https://flowus.cn/7cc6fdd0-2314-4fbf-8767-3d7919c0541c)

      [使用句法分析子树进行判定](https://flowus.cn/1c22edf4-0bfa-4269-944e-1078ff1ac91a)

    - 基于规则的（词语比例、标点）

      - 名词

      - 动词

      - 副词

      - 标点

    - 情感

      - title_subjectivity

      - 负面/正面

      - 极性比例/正负面极性

  - 文章

    [python 文本分析之处理和理解文本](https://zhuanlan.zhihu.com/p/340879728)

    - 文章结构

      - 段落的数量

      - 标题中的实体在文章中出现的词数（不太可行，wiki 上的受体名字比较专业）

    - 文章内容

      - 可读性（已完成）

      - 词数

        - 在 5000 词中的词出现的频率

        - 词性占比

          - 名词

          - 动词

          - 形容词

        [使用牛津 5000 词](https://flowus.cn/bf3c9e9f-35ea-4805-8c08-bfd952e62723)

      - 修辞

      - 情感极性和主观性（原数据集已给出，这里列出选用的）

        - global_subjectivity: 文章的主观程度

        - globalsentimentpolarity: 文章的情感极性

        - globalratepositive_words: 积极词的占比

        - globalratenegative_words: 消极词的占比

        - ratepositivewords: 非中性词积极词的占比

      - 不同符号出现的频率（尤其是分号，感叹号和问号） （相关系数很低，舍弃）

- 栏目

- 作者

  - 排除作者对文章热度的影响，将作者这类变量放入“其他因子”中实现。

