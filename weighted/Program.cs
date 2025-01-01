using System;
class Program{
	static int[,] nodes;
	static int N;
	
	static int NodeIndex=1;

	static int Main(string[] args){
		int[] edges={
			1,2,3,
			2,3,5,
			2,5,7,
			4,5,1,
			3,4,4,
			5,6,3
		};
		N=0;
		for(int x=0;x<edges.Length;x+=3){
			if(edges[x]>N)N=edges[x];
			if(edges[x+1]>N)N=edges[x+1];
		}
		++N;
		N-=NodeIndex;
		nodes=new int[N,N];
		for(int x=0;x<N;x++){
			for(int y=0;y<N;y++){
				nodes[x,y]=-1;
			}
		}
		float[] influence=new float[N];
		for(int x=0;x<edges.Length;x+=3){
			int a=edges[x]-NodeIndex;
			int b=edges[x+1]-NodeIndex;
			int w=edges[x+2];

			nodes[a,b]=w;
			nodes[b,a]=w;
		}

		bool[] visited=new bool[N];
		bool[] subVisited=new bool[N];
		bool check;
		
		//
		for(int x=0;x<N;x++){
			for(int y=0;y<N;y++){
				subVisited[y]=false;
			}
			visited[x]=true;
			check=false;
			while(!check){
				for(int y=0;y<N;y++){
					if(nodes[x,y]!=-1 && !(visited[y]||subVisited[y])){
						subVisited[y]=true;
						for(int z=0;z<N;z++){
							if(nodes[y,z]!=-1&&z!=x){
								int d=nodes[x,y]+nodes[y,z];
								if(nodes[x,z]>d || nodes[x,z]==-1){
									nodes[x,z]=d;
									nodes[z,x]=d;
								}
							}
						}
					}
				}
				check=visited[0]||subVisited[0];
				for(int y=1;y<N;y++){
					check=check&&(visited[y]||subVisited[y]);
				}
			}
		}
		//

		Console.WriteLine(N);
	
		for(int x=0;x<N;x++){
			influence[x]=0;
			for(int y=0;y<x;y++){
				influence[x]+=nodes[x,y];
			}
			for(int y=x+1;y<N;y++){
				influence[x]+=nodes[x,y];
			}
			influence[x]=(0.0f+N-1)/influence[x];
			Console.Write(influence[x]);
			Console.Write(',');
		}
		
		Console.Write('\n');	
	
		for(int x=0;x<N;x++){
			for(int y=0;y<N;y++){
				Console.Write(nodes[x,y]);
				Console.Write(',');
			}
			Console.Write('\n');
		}

		return 0;
	}
}
