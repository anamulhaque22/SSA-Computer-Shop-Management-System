"use client";
import ResponsivePagination from "react-responsive-pagination";
import Image from "next/image";
import { useState } from "react";
import FilterContainer from "./FilterContainer";
import ListOfProduct from "./ListOfProduct";

const ListOfProductPage = ({ productFor }) => {
  const totalPages = 10;
  const [currentPage, setCurrentPage] = useState(1);

  function handlePageChange(page) {
    setCurrentPage(page);
    // ... do something with `page`
  }
  const [isOpen, setIsOpen] = useState(false); // filter container
  return (
    <div className="container mt-5">
      <div className="drawer lg:auto-cols-auto lg:drawer-open">
        <input id="my-drawer" type="checkbox" className="drawer-toggle" />
        <div className="drawer-content">
          {/* <!-- Page content here --> */}

          <div className="w-full lg:pl-12">
            <div className="flex justify-between mb-5">
              <div className="w-2/5">
                <div className="form-control w-full">
                  <input
                    type="text"
                    placeholder="Search for anything..."
                    className="input input-bordered w-24 md:w-auto rounded-none"
                  />
                </div>
              </div>
              <div className="flex gap-6">
                <div className="flex gap-x-4 items-center">
                  <span>Sort by:</span>
                  <select className="select select-bordered rounded-none">
                    <option disabled selected>
                      Default
                    </option>
                    <option value={"most-popular"}>Most Popular</option>
                    <option value={"low"}>Low To High (Price)</option>
                    <option value={"high"}>High To Low (Price)</option>
                  </select>
                </div>
                <label
                  htmlFor="my-drawer"
                  className="lg:hidden flex gap-2 items-center border px-4 py-2 rounded-lg"
                  onClick={() => setIsOpen(true)}
                >
                  Filter{" "}
                  <Image
                    src={"/images/icon/filtter.svg"}
                    width={18}
                    height={18}
                    alt="filter icon"
                  />{" "}
                </label>
              </div>
            </div>
            <ListOfProduct />

            {/* <!-- Pagination --> */}
            <ResponsivePagination
              className="flex justify-center gap-x-4 mt-6 mb-7"
              pageItemClassName="flex items-center justify-center w-[40px] h-[40px] rounded-full border"
              total={totalPages}
              current={currentPage}
              onPageChange={(page) => handlePageChange(page)}
            />
          </div>
        </div>
        <div className="drawer-side">
          <label
            for="my-drawer"
            aria-label="close sidebar"
            className="drawer-overlay"
          ></label>
          {/* filter container  */}
          <div className="w-[300px]">
            <label
              htmlFor="my-drawer"
              aria-label="close sidebar"
              className="drawer-overlay"
            ></label>
            <FilterContainer />
          </div>
        </div>
      </div>
    </div>
  );
};

export default ListOfProductPage;
