import { useEffect, useState } from "react";
import { api } from "../api/api";

interface Produto {
  id: number;
  nome: string;
  codigo: string;
}

export function ProdutoList() {
  const [produtos, setProdutos] = useState<Produto[]>([]);

  useEffect(() => {
    api.get<Produto[]>("/produtos") // Ajuste a rota conforme sua API
      .then(res => setProdutos(res.data))
      .catch(err => console.error(err));
  }, []);

  return (
    <div>
      <h2>Lista de Produtos</h2>
      <ul>
        {produtos.map(p => (
          <li key={p.id}>{p.nome} - {p.codigo}</li>
        ))}
      </ul>
    </div>
  );
}
