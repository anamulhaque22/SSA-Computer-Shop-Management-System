import Image from "next/image";
import Category from "./Component/Category/Category";
import HomeProducts from "./Component/Home/HomeProducts";

export default function Home() {
  return (
    <main className="">
      <Category />
      <HomeProducts />
    </main>
  );
}
