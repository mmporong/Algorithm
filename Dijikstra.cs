namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            graph.Dijikstra(0);

            // graph.BFS(0);
        }
    }

    class Graph
    {
        int[,] adj = new int[6, 6]
        {
            {-1, 15, -1, 35, -1, -1 },
            {15, -1, 05, 10, -1, -1 },
            {-1, 05, -1, -1, -1, -1 },
            {35, 10, -1, -1, 05, -1 },
            {-1, -1, -1, 05, -1, 05 },
            {-1, -1, -1, -1, 05, -1 },

        };

        List<int>[] nodeList = new List<int>[]
        {
            new List<int>() {1, 3},
            new List<int>() {0, 2, 3},
            new List<int>() {1},
            new List<int>() {0, 1, 4},
            new List<int>() {3, 5},
            new List<int>() {4},
        };


        public void Dijikstra(int start)
        {
            bool[] visited = new bool[6];
            int[] distance = new int[6];
            int[] parent = new int[6];

            Array.Fill(distance, Int32.MaxValue);

            distance[start] = 0;
            parent[start] = 0;

            while (true)
            {
                // 초기화
                int closest = Int32.MaxValue;
                int now = -1;

                for (int i = 0; i < 6; i++)
                {
                    // 이미 방문 했으면
                    if (visited[i]) continue;
                    // 발견된 적이 없거나 멀리 있으면 
                    if (distance[i] == Int32.MaxValue || distance[i] >= closest) continue;

                    // 정보 갱신
                    closest = distance[i];
                    now = i;

                }

                // 후보가 없으면
                if (now == -1) break;

                // 방문
                visited[now] = true;

                // 인접한 정점을 조사해서 최단거리 갱신
                for (int next = 0; next < 6; next++)
                {
                    if (adj[now, next] == -1) continue;
                    if (visited[next]) continue;

                    int nextDist = distance[now] + adj[now, next];

                    if (nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
                }

            }


        }

        public void BFS(int start)
        {
            Queue<int> q = new Queue<int>();

            // 방문 체크
            isVisited[start] = true;
            parent[start] = start;
            distance[start] = 0;

            // 인큐
            q.Enqueue(start);

            // 큐 순회
            while (q.Count > 0)
            {
                int now = q.Dequeue();
                Console.WriteLine(now);

                for (int i = 0; i < nodeList[now].Count; i++)
                {
                    if (isVisited[nodeList[now][i]] == true) continue;


                    isVisited[nodeList[now][i]] = true;
                    q.Enqueue(nodeList[now][i]);

                    parent[nodeList[now][i]] = now;
                    distance[nodeList[now][i]] = distance[now] + 1;

                }
            }


        }
    }

}
