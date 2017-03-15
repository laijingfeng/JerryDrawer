using UnityEngine;
using Jerry;

public class DrawerTest : MonoBehaviour
{
    public Transform Pos1;
    public Transform Pos2;

    void Start()
    {
        JerryDrawer.Draw<DrawerElementPath>()
            .SetPoints(Pos1, Pos2)
            .SetColor(Color.yellow)
            .SetExecuteInEditMode(true);

        JerryDrawer.Draw<DrawerElementPath>()
            .SetPoints(Vector3.one, Vector3.zero, Vector3.left)
            .SetAddPoints(Vector3.one)
            .SetExecuteInEditMode(true);

        JerryDrawer.Draw<DrawerElementLabel>()
            .SetPos(new Vector3(1, 2, 1))
            .SetText("xxx")
            .SetColor(Color.red);

        JerryDrawer.Draw<DrawerElementCube>()
            .SetPos(new Vector3(1, 0, 1))
            .SetWire(true)
            .SetSize(Vector3.one)
            .SetSizeFactor(3)
            .SetColor(Color.green)
            .SetExecuteInEditMode(false);
    }
}