using OpenTK.Windowing.GraphicsLibraryFramework;

var windowFactory = new WindowFactory();
var window = windowFactory.Create();

var obstacles = new Obstacles();
var startPoint = new KeyPoint(1.5f, -1, window.MouseState);
var destinationPoint = new KeyPoint(-1.5f, 1, window.MouseState);
var visibilityGraph = new VisibilityGraph(obstacles);
var shortestPathLine = new ShortestPath(startPoint, destinationPoint, visibilityGraph);

var camera = new Camera();
var coordinateSystem = new DrawableWithSwitching(new CoordinateSystem());
var visibilityGraphRendering = new DrawableWithSwitching(visibilityGraph);
var renderer = new Renderer(new IDrawable[]{coordinateSystem, obstacles, visibilityGraphRendering, shortestPathLine, camera});

var obstaclesLoading = new ObstaclesLoading(obstacles);
var commands = new Commands(new List<Command>()
{
    new(Keys.I, obstaclesLoading.Load),
    new(Keys.D, coordinateSystem.Toggle),
    new(Keys.G, visibilityGraphRendering.Toggle)
});
var keyboardInput = new KeyboardInput(window.KeyboardState, commands);
var mouseInput = new MouseInput(window.MouseState, camera);
var updateCycle = new UpdateCycle(window, new IUpdatable[]{keyboardInput, mouseInput, startPoint, destinationPoint, shortestPathLine, renderer});

updateCycle.Run();
window.Run();