import React, { useState } from 'react';

function FiltroCategoria({ categorias, filtrarPorCategoria }) {
  const [categoriaSelecionada, setCategoriaSelecionada] = useState('');

  const handleCategoriaChange = (event) => {
    const categoria = event.target.value;
    setCategoriaSelecionada(categoria);
    filtrarPorCategoria(categoria); 
  };

  return (
    <div>
      <h3>Filtrar por Categoria</h3>
      <select value={categoriaSelecionada} onChange={handleCategoriaChange}>
        <option value="">Todas as Categorias</option>
        {categorias.map((categoria, index) => (
          <option key={index} value={categoria}>{categoria}</option>
        ))}
      </select>
    </div>
  );
}

export default FiltroCategoria;
