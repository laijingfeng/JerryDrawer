using UnityEngine;
using Jerry;

[ExecuteInEditMode]
public class DrawerTest : MonoBehaviour
{
    public Transform Pos1;
    public Transform Pos2;

    void Start()
    {
        JerryDrawer.Draw<Drawer2ElementPath>()
            .SetPoints(Pos1, Pos2)
            .SetColor(Color.yellow)
            .SetExecuteInEditMode(true);

        JerryDrawer.Draw<Drawer2ElementPath>()
            .SetPoints(Vector3.one, Vector3.zero, Vector3.left)
            .SetAddPoints(Vector3.one)
            .SetExecuteInEditMode(true);

        JerryDrawer.Draw<Drawer2ElementLabel>()
            .SetPos(new Vector3(1, 2, 1))
            .SetText("xxx")
            .SetColor(Color.red);

        JerryDrawer.Draw<Drawer2ElementCube>()
            .SetPos(new Vector3(1, 0, 1))
            .SetWire(true)
            .SetSize(Vector3.one)
            .SetSizeFactor(3)
            .SetColor(Color.green)
            .SetExecuteInEditMode(false);
    }

    void Update()
    {
    }
}