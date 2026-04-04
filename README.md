二次开发中...

##自用版

原版的底子真的很不错（架构清晰：UGUI+Canvas+Event），可以很简单的入门以及各种版本的自行深度定制，比起找过的许多其他蓝图更简洁明了易于理解使用和后期维护（例如大多存在一些Demo演示不全面/过于复杂/使用了其他依赖与杀鸡用牛刀的技术等），但在此基础上还需要进行一些美工与细节优化，以便适应更现代的实际应用。

## Fix Log

| Date | File | Fix |
|------|------|-----|
| 2026.4 | `Library/PackageCache/com.unity.2d.spriteshape@7.0.4/Runtime/SpriteShapeGenerator.cs` | CS1620: `ref ovc/oic/oec` → `out ovc/oic/oec` in `Tessellate` call (line ~1158) |
| 2025 | `Assets/RuntimeNodeEditor/Scripts/Graph/BezierCurveDrawer.cs` | 修复连接线锯齿（齿距）：`CreateLine()` 中为 `UILineRenderer` 加载 `line1` sprite，利用边缘 alpha 渐变软化线条边缘 |
| 2025 | `Assets/RuntimeNodeEditor/Scripts/Graph/NodeGraph.cs` | 平滑画布缩放：新增 `mouseMiddleButtomScaleFrameSpeed` 字段，用 `Sign*Abs*speed` 替代直接乘 scrollDelta，放大/缩小步距统一；拖拽画布由中键改为左键 |

