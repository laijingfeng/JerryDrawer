��Ŀ | ����
---|---
���� | JerryDrawer
Ŀ¼ | Github/��Ŀ
��ǩ | Github��JerryDrawer
��ע | [Github](https://github.com/laijingfeng/JerryDrawer)
���� | 2017-08-26 20:15:44

[TOC]

# ˵��

�༭�����ߣ����ٻ��ƻ����ĸ���ͼ��ʹ�õ�Gizmos��Handles������`Singleton.dll`��

Game��ͼҪ�����Ļ���ȷ�ϵ���Gizmos��

# ����ӿ�

`JerryDrawer`��
- `static T Draw<T>() where T : DrawerElementBase`
- `static T GetElement<T>(string id) where T : DrawerElementBase`
- `static void Remove(Drawer2ElementBase ele)`
- `static void RemoveByID(string id)`
- `static void RemoveAll()`

�����ӿڶ���`SetXXX`��ʽ���磺`SetColor`

ʾ����
```
JerryDrawer.Draw<DrawerElementPath>()
    .SetPoints(Pos1, Pos2)
    .SetColor(Color.yellow)
    .SetExecuteInEditMode(true);
```

��������TҲ�ܹ����ڶ��������ö�Ӧ���Ե���

# ֧�ֵ�����

- `DrawerElementPath` ·�����߶Ρ������
- `DrawerElementCube` ������
- `DrawerElementLabel` ��ǩ
- `DrawerElementBoxCollider` ��ײ����
- `DrawerElementRectTransform` RectTransform
- `DrawerElementGrid` ƽ������

# ��ϵ�����Է���

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
        - `SetMinPos` ������С���꣬Ҳ�����������
        - `SetGridSize` ���ø��Ӵ�С
        - `SetSize` ���ô�С��xyռ�������ӣ�����
        - `SetPlaneType` ����ƽ������
        - `SetCoordinateType` ��������ϵ

# ������־

## 2017-08-26

- DrawerElementGrid֧�ֱ�������ϵ��ȫ������ϵ

## 2017-08-01

- �޸�DrawerElementBoxCollider��BoxCollider.size��BoxCollider.center��֧��
- DrawerElementBoxCollider��target��Transform��ΪBoxCollider��һ��Transform���ж��BoxColliderʱ����ѡ���Ի���