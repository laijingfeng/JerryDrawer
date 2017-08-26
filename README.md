项目 | 内容
---|---
标题 | JerryDrawer
目录 | Github/项目
标签 | Github、JerryDrawer
备注 | [Github](https://github.com/laijingfeng/JerryDrawer)
更新 | 2017-08-26 20:15:44

[TOC]

# 说明

编辑器工具，快速绘制基本的辅助图，使用的Gizmos和Handles，依赖`Singleton.dll`。

Game视图要看见的话，确认点亮Gizmos。

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

绘制类型T也能挂载在对象上设置对应属性单用

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
        - `SetCoordinateType` 设置坐标系

# 更新日志

## 2017-08-26

- DrawerElementGrid支持本地坐标系和全局坐标系

## 2017-08-01

- 修复DrawerElementBoxCollider对BoxCollider.size和BoxCollider.center不支持
- DrawerElementBoxCollider的target由Transform改为BoxCollider，一个Transform下有多个BoxCollider时可以选择性绘制