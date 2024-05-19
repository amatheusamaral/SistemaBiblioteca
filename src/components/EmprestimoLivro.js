import React, { useState, useEffect } from 'react';
import axios from 'axios'; // Importe o axios para fazer requisições HTTP

function EmprestimoLivro() {
  const [livrosDisponiveis, setLivrosDisponiveis] = useState([]);
  const [livrosSelecionados, setLivrosSelecionados] = useState([]);
  const [periodo, setPeriodo] = useState('');

  useEffect(() => {
    setTimeout(() => {
      setLivrosDisponiveis(['Livro 1', 'Livro 2', 'Livro 3']); 
    }, 1000);
  }, []);

  const emprestarLivros = () => {
    if (livrosSelecionados.length > 0 && periodo.trim() !== '') {
      console.log('Livros emprestados:', livrosSelecionados);
      console.log('Período:', periodo);
      setLivrosSelecionados([]);
      setPeriodo('');
    }
  };

  return (
    <div>
      <h2>Empréstimo de Livros</h2>
      <select multiple value={livrosSelecionados} onChange={(e) => setLivrosSelecionados(Array.from(e.target.selectedOptions, option => option.value))}>
        {livrosDisponiveis.map((livro, index) => (
          <option key={index} value={livro}>{livro}</option>
        ))}
      </select>
      <input type="text" placeholder="Período de Empréstimo" value={periodo} onChange={(e) => setPeriodo(e.target.value)} />
      <button onClick={emprestarLivros}>Emprestar Livro(s)</button>
    </div>
  );
}

export default EmprestimoLivro;
