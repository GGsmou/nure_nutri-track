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
    if (filter.type === "edit") {
      return fetchAbstract("Recipes/" + filter.data.id, "PUT", data);
    }

    return fetchAbstract("Recipes/", "POST", data);
  });
};
