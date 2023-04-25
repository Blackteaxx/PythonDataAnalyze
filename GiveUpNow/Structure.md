简介
此数据集总结了 Mashable 在两年内发表的文章的一组异质特征。目标是预测社交网络（人气）的份额数量。

数据
这些文章由Mashable（www.mashable.com）出版，其内容作为复制权属于他们。因此，此数据集不共享原始内容，而是共享与它相关的一些统计数据。使用提供的网址公开访问和检索原始内容。

收购日期：2015 年 1 月 8 日

作者使用随机森林分类器和滚动窗口作为评估方法估计了估计的相对性能值。有关相对性能值的设置方式，请参阅他们的文章以了解更多详细信息。

属性信息：

```
url: URL of the article (non-predictive)

timedelta: Days between the article publication and the dataset acquisition (non-predictive)

ntokenstitle: Number of words in the title

ntokenscontent: Number of words in the content

nuniquetokens: Rate of unique words in the content

nnonstop_words: Rate of non-stop words in the content

nnonstopuniquetokens: Rate of unique non-stop words in the content

num_hrefs: Number of links

numselfhrefs: Number of links to other articles published by Mashable

num_imgs: Number of images

num_videos: Number of videos

averagetokenlength: Average length of the words in the content

numkeywords: Number of keywords in the metadata 13. datachannelislifestyle: Is data channel 'Lifestyle'?

datachannelis_entertainment: Is data channel 'Entertainment'?

datachannelis_bus: Is data channel 'Business'?

datachannelis_socmed: Is data channel 'Social Media'?

datachannelis_tech: Is data channel 'Tech'?

datachannelis_world: Is data channel 'World'?

kwminmin: Worst keyword (min. shares)

kwmaxmin: Worst keyword (max. shares)

kwavgmin: Worst keyword (avg. shares)

kwminmax: Best keyword (min. shares)

kwmaxmax: Best keyword (max. shares)

kwavgmax: Best keyword (avg. shares)

kwminavg: Avg. keyword (min. shares)

kwmaxavg: Avg. keyword (max. shares)

kwavgavg: Avg. keyword (avg. shares)

selfreferencemin_shares: Min. shares of referenced articles in Mashable

selfreferencemax_shares: Max. shares of referenced articles in Mashable

selfreferenceavg_sharess: Avg. shares of referenced articles in Mashable

weekdayismonday: Was the article published on a Monday?

weekdayistuesday: Was the article published on a Tuesday?

weekdayiswednesday: Was the article published on a Wednesday?

weekdayisthursday: Was the article published on a Thursday?

weekdayisfriday: Was the article published on a Friday?

weekdayissaturday: Was the article published on a Saturday?

weekdayissunday: Was the article published on a Sunday?

is_weekend: Was the article published on the weekend?

LDA_00: Closeness to LDA topic 0

LDA_01: Closeness to LDA topic 1

LDA_02: Closeness to LDA topic 2

LDA_03: Closeness to LDA topic 3

LDA_04: Closeness to LDA topic 4

global_subjectivity: Text subjectivity

globalsentimentpolarity: Text sentiment polarity

globalratepositive_words: Rate of positive words in the content

globalratenegative_words: Rate of negative words in the content

ratepositivewords: Rate of positive words among non-neutral tokens

ratenegativewords: Rate of negative words among non-neutral tokens

avgpositivepolarity: Avg. polarity of positive words

minpositivepolarity: Min. polarity of positive words

maxpositivepolarity: Max. polarity of positive words

avgnegativepolarity: Avg. polarity of negative words

minnegativepolarity: Min. polarity of negative words

maxnegativepolarity: Max. polarity of negative words

title_subjectivity: Title subjectivity

titlesentimentpolarity: Title polarity

abstitlesubjectivity: Absolute subjectivity level

abstitlesentiment_polarity: Absolute polarity level

shares: Number of shares (target)
```
