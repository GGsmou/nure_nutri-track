import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { Recepie } from "../types/Recepie";

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
      // newIngredientIds: data.ingredients
      //   .map((ingredient) => INGREDIENTS.find((i) => i.name === ingredient)?.id)
      //   .filter(Boolean),
      name: data.name + `${data.isPremium ? "*" : ""}`,
      newIngredientIds: [],
      existingIngredients: [],
      newIngredients: [],
      votes: data.votes,
    });
  });
};
