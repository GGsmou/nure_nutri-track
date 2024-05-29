import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";

export const useExerciseDelete = () => {
  return useMutation((data: { id: number }) => {
    return fetchAbstract("Exercises/" + data.id, "DELETE");
  });
};
