/*
 * Criado por SharpDevelop.
 * Usuário: Paulo 
 * Data: 23/06/2021
 * Hora: 20:04
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace campo_minado
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Random rnd = new Random();
		Button[] buttons = new Button[50];
		int[] vetornum = new int[50];
		
		void gerarVetor()
		{
			int numCandidato= 0;
			int cont=0 ;
			
			//zerar vetor
			for (int i=0; i< vetornum.Length; i++)
				vetornum[i]=0;
			
			for (int i=0; i<50; i++) //garante ger de 50n 
			{
				do{
					numCandidato = rnd.Next(0,6); //ger numcandidato(ger 0,1,2,3,4,5)
					cont=0;
					foreach (int numero in vetornum) //testa numCandidato com todos antes
					{
						if (numCandidato==numero)
							cont++;
					}
				} while (cont==8); // só sai de looping com um numCandidato que aparece menos de 8x (para dividir =, ex: 50/6 = +-8
				vetornum[i] = numCandidato;
			}
		}
		
		public MainForm()			
		{
	
			InitializeComponent();
			
			gerarVetor();
			
			int x=0, y=0 ;
			
			/*
			Button[] buttons = new Button[50];*/
			
			/*
			Random rnd = new Random();*/			
			
			for(int i = 0; i <buttons.Length; i++){
				if (x==500)
				{
					x=0;
					y+=50;
				}
				
				buttons[i]= new Button();
				buttons[i].Parent=this;
				buttons[i].Text="?";
				buttons[i].Left += 10+ x;
				buttons[i].Top += 5+ y;
				buttons[i].Width= 45;
				buttons[i].Height= 45;
				buttons[i].Name=i.ToString();
				//eventos do componente +=
				buttons[i].Click+=clickbutton; 
				x+=100;	
			}
			
			blockbutton(); 
		}
		
		int contLinha=4;
		int pontuacao=0;

		void blockbutton ()
		{
			for (int i=0; i<50; i++)
			{
				if (i>contLinha)
					buttons[i].Enabled=false;
				
				else 
					buttons[i].Enabled=true;		
			}
		}
		
		//evento click
		void clickbutton (object sender, EventArgs e ){
			string numbutton= (sender as Button).Name;
			int n = int.Parse(numbutton);
			
			if (n > contLinha-5)
			{
				buttons[n].Text= vetornum[n].ToString(); //desbloquear prxa  linha
				pontuacao+=vetornum[n];
				label1.Text="Sua pontuação foi: "+pontuacao; //dell apaga para a esquerda
				
				if(pontuacao>=25)
				{
					MessageBox.Show("BUUM! GAME OVER BABY", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Restart();
				}
				else if (n >44)
	    		{
					MessageBox.Show("Parabéns", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					Application.Restart();
				}
						
				//desbloquear prxa  linha
				contLinha+=5;
				blockbutton();
			}
		}
	}
}
