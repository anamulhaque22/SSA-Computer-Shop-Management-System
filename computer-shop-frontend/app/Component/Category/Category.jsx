import Image from "next/image";
import React from "react";
import CategoryItem from "./CategoryItem";

const Category = () => {
  return (
    <div className="container section-space">
      <h2 className="text-3xl font-semibold text-center mb-9">
        Shop with Categorys
      </h2>
      <div className="grid grid-cols-6 gap-x-3 gap-y-5">
        <CategoryItem />
        <CategoryItem />
        <CategoryItem />
        <CategoryItem />
        <CategoryItem />
        <CategoryItem />
        <CategoryItem />
        <CategoryItem />
        <CategoryItem />
      </div>
    </div>
  );
};

export default Category;
