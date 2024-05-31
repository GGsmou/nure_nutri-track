import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { Recepie } from "../types/Recepie";
import { INGREDIENTS } from "../utils/ingredients";

export const useRecepieCreate = (
  filter:
    | {
        type: "edit";
        data: { id: string };
      }
    | {
        type: "create";
      },
) => {
  return useMutation((data: Recepie) => {
    const type = filter.type === "edit" ? "PUT" : "POST";
    return fetchAbstract("Recipes/", type, {
      ...data,
      newIngredientIds: data.ingredients
        .map((ingredient) => INGREDIENTS.find((i) => i.name === ingredient)?.id)
        .filter(Boolean),
      existingIngredients: [],
      newIngredients: [],
    });
  });
};
