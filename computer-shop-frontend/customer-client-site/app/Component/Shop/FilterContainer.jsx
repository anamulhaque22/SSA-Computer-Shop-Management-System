import FilterByAvailability from "../Filter/FilterByAvailability";
import FilterByBrand from "../Filter/FilterByBrand";
import FilterByPrice from "../Filter/FilterByPrice";

const FilterContainer = () => {
  return (
    <>
      <FilterByPrice />
      <FilterByBrand />
      <FilterByAvailability />
    </>
  );
};

export default FilterContainer;
