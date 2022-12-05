# Medusa and Sisters
reminder: the rotation of the plane should be bigger than 80 degree! //or the avatar will roll and fall!! 已修复，改变senser的offset高度就可以，去掉falling动画是代价:(

故事简介：三姐妹同心协力干掉魔王O(∩_∩)O


===== 操作按键 =====

手柄模式：左摇杆移动，左摇杆长按奔跑（需解锁）//右摇杆调整视野//A跳跃B翻滚Y攻击//原地跳跃闪避（需解锁）

纯键盘模式：WSAD移动，长按奔跑（需解锁）//↑↓←→调整视野//K跳跃L翻滚J攻击//原地跳跃闪避（需解锁）

键鼠模式：WSAD移动，长按奔跑（需解锁）//鼠标移动调整视野//F跳跃右键翻滚左键攻击//原地跳跃闪避（需解锁）

===== 攻击列表 =====

四连击：attack, attack, attack, ----attack

===== 能力解锁列表 =====

（能拆开卖就拆开）

最基础：能够攻击一下，走路，跳跃，jab（原地跳跃），移动视角

jab能够闪避 → canRun → （学会连招）canComboA1 → canComboA2 → （翻滚无敌）canRoll → （学会躲避）canRollDistance → （跳跃和翻滚中间可以加攻击）canFreeAttack

===== 怪物设置 =====

美杜莎关四种怪物外形的怪，生成逻辑：Create random time seed, e.g. there are 4 spawn points, normalMonster is (4, 5, 6, 2), which means there are 4 monsters at the 1st spawning point etc. They will appear one by one at time 'level time/4, level time/4*2, level time/4*3, level time/4*4'.

姐姐们是神话生物的怪。（素材包太强了，买了不用真可惜）

=============== 开发日志 ==================

12.5a:配置四种怪物，给怪物攻击加卡肉效果，跳台阶卡顿的解决方法，怪物死亡特效，修复吸血鬼和肉怪物攻击，空气墙，路线
![11.21a](Diary/png12.5a.png)
![11.21a](Diary/png12.5b.png)
![11.21a](Diary/png12.5c.png)
![11.21a](Diary/png12.5d.png)
![11.21a](Diary/png12.5e.png)

新的姐姐Stheno模型置入

![11.21a](Diary/png12.5f.png)

UI设计+施工，如图

![11.21a](Diary/jpg12.5g.jpg)
![11.21a](Diary/png12.5g.png)

 12.4：怪物模型、怪物与关卡的ScriptableObj、单个敌人控制、敌人随机生成脚本们
 ![11.21a](Diary/png12.4a.png)
 击中刀光、怪物攻击逻辑与动画整合、战斗流程，震动镜头、“卡肉”
  ![11.21a](Diary/png12.4b.png)
  ![11.21a](Diary/png12.4c.png)
  ![11.21a](Diary/png12.4d.png)
  ![11.21a](Diary/png12.4e.png)
 姐姐的建模在建了
  ![11.21a](Diary/jpg12.4.jpg)
  踩雷git同步，下次一定用plasticSCM！

 12.3：挥舞的刀光特效；受击动画；场景机关受伤
 ![11.21a](Diary/png12.3a.png)
 ![11.21a](Diary/png12.3b.png)

 11.30/12.1：加入天空盒与场景资源，调整核心玩法：一阶段trigger距离触发；二阶段时间同步触发；三阶段复现行动
 ![11.21a](Diary/png12.1.png)
 
 11.27：
 
 ===== 【MyBotton & MyTimer】 =====
 
 IsPressing：正在按下；
 
 OnPressed：刚开始按下；
 
 OnReleased：松手；
 
 IsExtending：记录松手后的1s，可用于double trigger
 
 IsDelaying：记录按键后的2s，可用于蓄力攻击
 
 放入了一个可以获得跑步能力的箱子，能够依次解锁cambo、翻滚、距离翻滚、自用攻击等不同的ability；锁定敌人功能
  ![11.21a](Diary/png11.27a.png)
  ![11.21a](Diary/png11.27b.png)
  ![11.21a](Diary/png11.27c.png)
 
 
 11.26: 
 加入四连技攻击，前三下节奏快，后一下节奏慢（动画event）；用GetLayerWeight等找当前动画状态，lerp攻击模式与移动模式切换；物理摩擦材质修bug；rigi与animation不同级的rootmotion处理；加上武器模型；手柄输入！abstract类控制面向对象；加个盾牌模型；传键盘/键盘+鼠标控制攻击和移动镜头；Botton的功能类别集成！
 ![11.21a](Diary/png11.26a.png)
 ![11.21a](Diary/png11.26b.png)
 
 11.25：
 更新URP，导入美杜莎人物模型、绘制texture、绑定骨骼、导入动画、复用animator controller、设置post processing
![11.21a](Diary/png11.25a.png)
![11.21a](Diary/png11.25b.png)
![11.21a](Diary/png11.25c.png)
![11.21a](Diary/png11.25d.png)
 
 11.24: 
 原地跳跃闪避（后撤功能）；相机转动与移动、lerp平滑移动；丝西娜（红色姐姐）人设
![11.21a](Diary/png11.24.png)
![11.21a](Diary/11.24a.jpg)

 11.20-11.22：
 主要人设以及美杜莎建模（未绑骨）blender和nomad
![11.21a](Diary/11.21a.jpg)
![11.21b](Diary/11.21b.jpg)
![11.22a](Diary/png11.22.png)
 
 11.19：
 加入跳跃、奔跑、转弯平滑、地面检测、下落翻滚等基础移动
 
 wasd移动；j跳跃；k翻滚；left shift跑步
![11.19](Diary/11.19.png)
 
 11.17-11.20：git创建
 








