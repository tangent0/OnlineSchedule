package com.example.onlineschedule.entity;

import java.util.ArrayList;



public class Dijkstra {

	public Dijkstra(){
		Init();
	}
	/**节点名称数组*/
	public ArrayList<MapNode> nodeNames;
	public int [][] map;
	public int nodeCount;
	
	private final int Max=10000;


	public void Init(){
		nodeCount = 29;
		map = new int[30][30];
		for(int i=0;i<=nodeCount;i++){
			for(int j=0;j<nodeCount;j++){
				map[i][j] = Max;
			}
		}
		//教学楼号
		nodeNames = new ArrayList<MapNode>();
		nodeNames.add(new MapNode("1",39.061882,117.135433));
		nodeNames.add(new MapNode("2",39.061458,117.135531));
        nodeNames.add(new MapNode("3",39.060916,117.135306));
        nodeNames.add(new MapNode("4",39.060066,117.135317));
        nodeNames.add(new MapNode("5",39.059475,117.135553));
        nodeNames.add(new MapNode("6",39.059008,117.13536));
        nodeNames.add(new MapNode("7",39.061216,117.133631));
        nodeNames.add(new MapNode("8",39.060749,117.133781));
        nodeNames.add(new MapNode("9",39.060166,117.133566));
        nodeNames.add(new MapNode("10",39.059733,117.133588));
        nodeNames.add(new MapNode("11",39.05895,117.133695));
        nodeNames.add(new MapNode("12",39.059217,117.132944));
        nodeNames.add(new MapNode("13",39.0583,117.133695));
        nodeNames.add(new MapNode("14",39.057684,117.133781));
        nodeNames.add(new MapNode("15",39.057584,117.132944));
        nodeNames.add(new MapNode("16",39.056851,117.133652));
        nodeNames.add(new MapNode("17",39.056284,117.133652));
        nodeNames.add(new MapNode("18",39.056238,117.131091));
        nodeNames.add(new MapNode("19",39.056784,117.131348));
        nodeNames.add(new MapNode("20",39.05743,117.131396));
        nodeNames.add(new MapNode("21",39.057971,117.130978));
        nodeNames.add(new MapNode("22",39.058296,117.131139));
        nodeNames.add(new MapNode("23",39.058925,117.131128));
        nodeNames.add(new MapNode("24",39.059646,117.130779));
        nodeNames.add(new MapNode("25",39.060037,117.131015));
        nodeNames.add(new MapNode("26",39.061058,117.131026));
        nodeNames.add(new MapNode("27",39.062995,117.130903));
        nodeNames.add(new MapNode("28",39.062995,117.133805));
        //图书馆的编号
        nodeNames.add(new MapNode("29",39.062982,117.1323));
        

		map[0][1]=2;map[0][27]=7;
		map[1][0]=2;map[1][2]=2;
		map[2][1]=3;map[2][7]=3;
		map[3][4]=3;map[3][8]=5;
		map[4][3]=3;map[4][5]=2;
		map[5][4]=2;  map[5][10]=3;
		map[6][7]=3;map[6][25]=4;  map[6][27]=7;
		map[7][2]=3;map[7][6]=3;map[7][8]=4;
		map[8][7]=4;map[8][3]=5;map[8][9]=2;  map[8][24]=5;
		map[9][8]=2;map[9][11]=4;
		map[10][11]=4;map[10][12]=4;  map[10][5]=3;
		map[11][9]=4;map[11][10]=4;map[11][22]=4;
		map[12][10]=4;map[12][13]=3;  map[12][21]=7;
		map[13][12]=3;map[13][14]=3;
		map[14][13]=3;map[14][15]=3;  map[14][19]=4;
		map[15][14]=3;map[15][16]=2;
		map[16][15]=2;
		map[17][18]=3;
		map[18][17]=3;map[18][15]=4;map[18][19]=3;
		map[19][18]=3;map[19][20]=2;  map[19][14]=4;
		map[20][19]=2;map[20][21]=1;
		map[21][20]=1;map[21][22]=4;  map[21][12]=7;
		map[22][11]=4;map[22][21]=4;map[22][23]=3;
		map[23][22]=3;map[23][24]=2;
		map[24][23]=2;map[24][25]=4;  map[24][8]=5;
		map[25][6]=4;map[25][24]=4;  map[25][26]=6;
		map[26][27]=7;  map[26][25]=6;
		map[27][0]=7;map[27][26]=7;  map[27][6]=7;
		//图书馆的下标
		map[28][26]=3; map[28][27]=4;
		map[26][28]=3; map[27][28]=4;
		
	}
	public MapNode findNearestBuilding(double longitude,double latitude)
	{
		MapNode node = null;
		int cnt = nodeNames.size();
		double[] distance = new double[cnt];
		for(int i=0;i<cnt;i++)
		{
			node = nodeNames.get(i);
			distance[i] = node.distance(latitude,longitude);
		}
		
		int index = -1;
		double minDistance = 999999999;
		for(int i=0;i<cnt;i++)
		{
			if(distance[i] < minDistance)
			{
				minDistance = distance[i];
				index = i;
			}
		}

		node = nodeNames.get(index);		
		return node;
	}
    public int findNodeByName(String name)
    {
    	if(name.indexOf("-",0) == -1) {
		    for(int i=0;i<nodeCount;i++)
		    {
		        MapNode node = this.nodeNames.get(i);
		        if(node.name.equalsIgnoreCase(name))
		        {
		            return i;
		        }
		    }
    	}else {
		    for(int i=0;i<nodeCount;i++)
		    {
		        MapNode node = this.nodeNames.get(i);
		        if(node.name.equalsIgnoreCase(name.substring(0,name.indexOf("-",0))))
		        {
		            return i;
		        }
		    }
    	}
    	
        return -1;
    }
	public String computeShortestPath(int start,int end)
	{
		int D[] = new int[nodeCount];             //各顶点的距离值
		int P[] = new int[nodeCount],S[] = new int[nodeCount];    
		int i=0,j=0,k=0,vl=0,pre=0;
		int min,inf=10000;
		vl=start;
		String path = "";
		if(start<0&&start>nodeCount&&end<0&&end>nodeCount)
			return path;
		else
		{
			
			for( i=0;i<nodeCount;i++)  
			{
				D[i]=map[vl][i];
				if(D[i]!=Max) 
					P[i]=start+1; 
				else P[i]=0;
			}
			for( i=0;i<nodeCount;i++) 
			{
				S[i]=0;  
			}
			S[vl]=1;D[vl]=0;
			for( i=0;i<nodeCount-1;i++)
			{
				min=inf;
				for(j=0;j<nodeCount;j++) 
				{
					if((S[j] == 0 )&&(D[j]<min))
					{
						min=D[j];k=j;
					}
				}
				S[k]=1;
				for(j=0;j<nodeCount;j++)
				{
					if((S[j]==0)&&(D[j]>D[k]+map[k][j])) 
					{
						D[j]=D[k]+map[k][j];
						P[j]=k+1;
					}
				}
			}
			//printf("\n两节点之间的最短距离为:   %d\n\n两节点间最短路径为:\n\n%s",D[end-1],vexs[end-1]);
			pre=P[end];
			path = nodeNames.get(end).toString();
			while(pre!=0)   
			{
				path += "<--" +nodeNames.get(pre-1);
				pre=P[pre-1];
			}
			
			
			return path;
		}
	}

}
