import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { ExercisesNote } from "../types/ExercisesNote";

export const useExercisesNoteCreate = (
  filter:
    | {
        type: "edit";
        data: { id: string };
      }
    | {
        type: "create";
      },
) => {
  return useMutation((data: ExercisesNote) => {
    const type = filter.type === "edit" ? "PUT" : "POST";
    return fetchAbstract("ExercisesNotes/", type, data);
  });
};
