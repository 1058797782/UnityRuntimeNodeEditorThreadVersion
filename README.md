Still in the process of secondary development

## Fix Log

| Date | File | Fix |
|------|------|-----|
| 2025 | `Library/PackageCache/com.unity.2d.spriteshape@7.0.4/Runtime/SpriteShapeGenerator.cs` | CS1620: `ref ovc/oic/oec` → `out ovc/oic/oec` in `Tessellate` call (line ~1158) |
| 2025 | `Assets/RuntimeNodeEditor/Scripts/Graph/BezierCurveDrawer.cs` | 修复连接线锯齿（齿距）：`CreateLine()` 中为 `UILineRenderer` 加载 `line1` sprite，利用边缘 alpha 渐变软化线条边缘 |
| 2025 | `Assets/RuntimeNodeEditor/Scripts/Graph/NodeGraph.cs` | 平滑画布缩放：新增 `mouseMiddleButtomScaleFrameSpeed` 字段，用 `Sign*Abs*speed` 替代直接乘 scrollDelta，放大/缩小步距统一；拖拽画布由中键改为左键 |

