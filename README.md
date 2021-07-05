# Game05

## 1.整体框架

使用Unity引擎的UGUI实现界面

## 2.目录结构
```
｜——Scripts   
｜  ｜——GameControl                    #游戏流程控制
｜  ｜  ｜——GameRefresh                #游戏赛季刷新     
｜  ｜  ｜——GenerateReward             #产生奖励
｜  ｜  ｜——RankAndRewardUIControl     #界面显示
｜  ｜  ｜——ScoreAndRinkSet            #分数和段位设置
｜  ｜   
｜  ｜——PlayerInfoManager             #玩家信息管理
｜     ｜——CoinsManager               #金币管理
｜     ｜——PlayerInfo                 #玩家信息
｜     ｜——ScoreManager               #分数管理
```
## 3.代码逻辑

代码逻辑分为三层，分别是main、controller、model。 mian层负责读取和更新数据，controller控制UI界面的显示隐藏，model层显示界面具体信息。
RankAndRewardUIControl负责控制主界面显示，ScoreAndRinkSet分数和段位信息设置，GenerateReward负责产生奖励，GameRefresh负责游戏赛季刷新，
PlayerInfo负责存储玩家数据，ScoreManager负责玩家分数信息管理，CoinsManager负责玩家金币信息管理。


## 4.存储设计

玩家的分数和金币数据设为静态数据存在PlayerInfo脚本里。
