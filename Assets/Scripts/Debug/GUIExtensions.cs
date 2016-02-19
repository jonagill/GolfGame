using UnityEngine;

public static class GUIExtensions
{
    private static Material _debugMaterial;

    /// <summary>
    /// Should be called from OnPostRender
    /// </summary>
    public static void DrawLine(Vector3 startPos, Vector3 endPos, Color color)
    {
        EnsureMaterial();

        GL.PushMatrix();
        _debugMaterial.SetPass(0);
        GL.LoadOrtho();
        GL.Begin(GL.LINES);
        GL.Color(color);
        GL.Vertex(new Vector3(startPos.x / Screen.width, startPos.y / Screen.height, 0));
        GL.Vertex(new Vector3(endPos.x / Screen.width, endPos.y / Screen.height, 0));
        GL.End();
        GL.PopMatrix();
    }

    private static void EnsureMaterial()
    {
        if (_debugMaterial == null)
        {
            _debugMaterial = new Material(Shader.Find("Sprites/Default"));
        }
    }
}
