import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { Recepie } from "../types/Recepie";

export const useRecepieChangeVote = () => {
  return useMutation(
    (data: { res: Recepie; id: string; type: "up" | "down" }) => {
      return fetchAbstract("Recipes/", "PUT", {
        ...data.res,
        servingSizeInGrams: data.res.votes + (data.type === "up" ? 1 : -1),
        newIngredientIds: [],
        existingIngredients: [],
        newIngredients: [],
      });
    },
  );
};
