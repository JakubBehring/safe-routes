using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace safe_routes.Models.PathFinder
{
    public class DijkstrasAlgorithm
    {
        private readonly int noParent = -1;
        private List<int> shortestPath = new List<int>();
        public List<int> dijkstra(RouteAndEdge[,] adjacencyMatrix,
                                            int startVertex, int endVertex)
        {
            int nVertices = adjacencyMatrix.GetLength(0);
            double[] shortestDistances = new double[nVertices];
            bool[] added = new bool[nVertices];


            for (int vertexIndex = 0; vertexIndex < nVertices;
                                                vertexIndex++)
            {
                shortestDistances[vertexIndex] = int.MaxValue;
                added[vertexIndex] = false;
            }

            shortestDistances[startVertex] = 0;
            int[] parents = new int[nVertices];
            parents[startVertex] = noParent;

            for (int i = 1; i < nVertices; i++)
            {
                int nearestVertex = -1;
                double shortestDistance = int.MaxValue;
                for (int vertexIndex = 0;
                        vertexIndex < nVertices;
                        vertexIndex++)
                {
                    if (!added[vertexIndex] &&
                        shortestDistances[vertexIndex] <
                        shortestDistance)
                    {
                        nearestVertex = vertexIndex;
                        shortestDistance = shortestDistances[vertexIndex];
                    }
                }
                added[nearestVertex] = true;

                for (int vertexIndex = 0;
                        vertexIndex < nVertices;
                        vertexIndex++)
                {
                    double edgeDistance = adjacencyMatrix[nearestVertex, vertexIndex]?.Edge ?? 0; 

                    if (edgeDistance > 0
                        && ((shortestDistance + edgeDistance) <
                            shortestDistances[vertexIndex]))
                    {
                        parents[vertexIndex] = nearestVertex;
                        shortestDistances[vertexIndex] = shortestDistance +
                                                        edgeDistance;
                    }
                }
            }
            GetPathToVertex(endVertex, parents);
            return shortestPath;
        }
      
        private void GetPathToVertex(int currentVertex,
                                    int[] parents)
        {
            if (currentVertex == noParent)
            {
                return;
            }
            GetPathToVertex(parents[currentVertex], parents);
            shortestPath.Add(currentVertex);
        }
    }
}
