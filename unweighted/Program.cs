using System;
class Program{
	static int[,] nodes;
	static int N;

	static int distSum(int v){
		int n;
		int p;
		int[] q=new int[N];
		bool[] visited=new bool[N];
		visited[v]=true;

		int d=0;
	
		q[0]=v;
		n=1;
		p=0;

		int total=0;
		while(n!=N){
			int _n=n;
			++d;
			for(;p<_n;p++){
				for(int y=1;y<=nodes[q[p],0];y++){
					int temp=nodes[q[p],y];
					if(!visited[temp]){
						visited[temp]=true;
						q[n++]=temp;
						total+=d;
					}
				}
			}
		}		
		return total;
	}
	
	static int Main(string[] args){
		int[] edges= {0,1,1,2,1,4,3,4,2,3,4,5};
	
		N=0;
		for(int x=0;x<edges.Length;x++){
			if(edges[x]>N)N=edges[x];
		}
		++N;	
		nodes=new int[N,N];
		float[] influence=new float[N];
		for(int x=0;x<edges.Length;x+=2){
			int c=edges[x];
			nodes[c,0]++;
			nodes[c,nodes[c,0]]=edges[x+1];
			c=edges[x+1];
			nodes[c,0]++;
			nodes[c,nodes[c,0]]=edges[x];
		}

		for(int x=0;x<N;x++){
			influence[x]=(0.0f+N-1)/distSum(x);
			Console.WriteLine(influence[x]);
		}

		return 0;
	}
}
