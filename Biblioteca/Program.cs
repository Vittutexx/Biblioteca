using System;
using System.Collections.Generic;


///
/// TEMA DO PROJETO: BIBLIOTECA
/// 


// Classe abstrata para representar um item da biblioteca
abstract class ItemBiblioteca
{
    protected string Titulo { get; set; }
    protected string Autor { get; set; }
    protected bool Disponivel { get; set; }

    // Método sobrescrito para exibir informações do item da biblioteca
    public override string ToString()
    {
        return $"Título: {Titulo}\nAutor: {Autor}\n";
    }

    // Método abstrato para emprestar o item da biblioteca
    public abstract void Emprestar();
}

// Classe para representar um livro
class Livro : ItemBiblioteca
{
    //Construtor
    public Livro(string titulo, string autor)
    {
        Titulo = titulo;
        Autor = autor;
        Disponivel = true;
    }

    // Método para checar a disponibilidade do livro
    public void ChecarDisponibilidade()
    {
        if (Disponivel)
        {
            Console.WriteLine("O livro está disponível para empréstimo\n");
        }
        else
        {
            Console.WriteLine("O livro não está disponível para ser emprestado.\n");
        }
    }

    // Método para emprestar um livro
    public override void Emprestar()
    {
        if (Disponivel)
        {
            Disponivel = false;
            Console.WriteLine("Livro emprestado com sucesso!\n");
        }
        else
        {
            Console.WriteLine("Livro não está disponível para empréstimo.\n");
        }
    }
}

// Classe para representar a biblioteca
class Biblioteca
{
    private List<ItemBiblioteca> itens = new List<ItemBiblioteca>();

    // Método para adicionar um item à biblioteca
    public void AdicionarItem(ItemBiblioteca item)
    {
        itens.Add(item);
    }

    // Método para listar todos os itens da biblioteca
    public void ListarItens()
    {
        foreach (var item in itens)
        {
            Console.WriteLine(item);
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criando alguns livros
        Livro livro1 = new Livro("Memórias Póstumas de Brás Cubas", "Machado de Assis");
        Livro livro2 = new Livro("Capitães da Areia", "Jorge Amado");

        // Criando o objeto biblioteca
        Biblioteca biblioteca = new Biblioteca();

        // Adicionando os livros ao objeto biblioteca
        biblioteca.AdicionarItem(livro1);
        biblioteca.AdicionarItem(livro2);

        // Listando os itens da biblioteca
        Console.WriteLine(" ========== ITENS DA BIBLIOTECA ==========\n");
        biblioteca.ListarItens();

        // Checando se o livro está disponível
        Console.WriteLine(" ========== DISPONIBILIDADE ==========\n");
        Console.WriteLine("Checando se o livro Capitães da Areia está disponível para empréstimo:\n");
        livro2.ChecarDisponibilidade();

        // Emprestando um livro
        Console.WriteLine("Emprestando o livro 'Capitães da Areia':");
        livro2.Emprestar();

        // Tentando emprestar o mesmo livro novamente
        Console.WriteLine("Tentando emprestar o livro 'Capitães da Areia' novamente:");
        livro2.Emprestar();

        // Checando novamente a disponibilidade do livro que já foi emprestado anteriormente.
        Console.WriteLine(" ========== DISPONIBILIDADE ==========\n");
        livro2.ChecarDisponibilidade();
        Console.ReadLine();
    }
}
