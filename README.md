项目 | 内容
---|---
标题 | JerryDrawer
目录 | Github/项目
标签 | Github、JerryDrawer
备注 | [Github](https://github.com/laijingfeng/JerryDrawer)
更新 | 2017-06-19 00:08:21

[TOC]

# 说明

编辑器工具，快速绘制基本的辅助图，使用的Gizmos和Handles，依赖`Singleton.dll`。

Game视图要看见的话，点亮Gizmos。

# 对外接口

`JerryDrawer`：
- `static T Draw<T>() where T : DrawerElementBase`
- `static T GetElement<T>(string id) where T : DrawerElementBase`
- `static void Remove(Drawer2ElementBase ele)`
- `static void RemoveByID(string id)`
- `static void RemoveAll()`

其他接口都用`SetXXX`形式，如：`SetColor`

示例：
```
JerryDrawer.Draw<DrawerElementPath>()
    .SetPoints(Pos1, Pos2)
    .SetColor(Color.yellow)
    .SetExecuteInEditMode(true);
```

# 支持的类型

- `DrawerElementPath` 路径、线段、多边形
- `DrawerElementCube` 立方体
- `DrawerElementLabel` 标签
- `DrawerElementBoxCollider` 碰撞盒子
- `DrawerElementRectTransform` RectTransform
- `DrawerElementGrid` 平面网格

# 关系和属性方法

- `DrawerElementBase`
    - `SetExecuteInEditMode()`
    - `SetID()`
    - `SetLife()`
    - `SetColor()`
    - `SetOnlyDrawSelected()`
    - `DrawerElementBoxCollider`
        - `SetTarget()`
        - `SetDrawType()`
    - `DrawerElementRectTransform`
        - `SetTarget()`
    - `DrawerElementCube`
        - `SetPos()`
        - `SetWire()`
        - `SetSize()`
        - `SetSizeFactor()`
    - `DrawerElementLabel`
        - `SetPos()`
        - `SetText()`
    - `DrawerElementPath`
        - `SetPoints()`
        - `SetAddPoints()`
    - `DrawerElementGrid`
        - `SetMinPos` 设置最小坐标，也就是起点坐标
        - `SetGridSize` 设置格子大小
        - `SetSize` 设置大小，xy占几个格子，整数
        - `SetPlaneType` 设置平面类型