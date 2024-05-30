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
    const type = filter.type === "edit" ? "PUT" : "POST";
    return fetchAbstract("Exercises/", type, data);
  });
};
