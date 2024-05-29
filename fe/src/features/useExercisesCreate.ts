import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { Exercise } from "../types/Exercise";

export const useExercisesCreate = (
  filter:
    | {
        type: "edit";
        data: { id: string };
      }
    | {
        type: "create";
      },
) => {
  return useMutation((data: Exercise) => {
    if (filter.type === "edit") {
      return fetchAbstract("Exercises/" + filter.data.id, "PUT", data);
    }

    return fetchAbstract("Exercises/", "POST", data);
  });
};
