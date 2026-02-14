import { ProdutoList } from "../components/ProdutoList";
import { ProdutoForm } from "../components/ProdutoForm";

export function Home() {
  return (
    <div>
      <h1>MinhaApi Frontend</h1>
      <ProdutoForm />
      <ProdutoList />
    </div>
  );
}
